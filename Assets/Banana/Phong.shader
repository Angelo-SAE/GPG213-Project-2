Shader "Unlit/Phong"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DiffusedColor("DiffusedColor", color) = (1,1,1,1)
        _AmbientColor("AmbientColor", color) = (1,1,1,1)
        _SpecularColor("SpecularColor", color) = (1,1,1,1)
        _RimLightColor("RimLightColor", color) = (1,1,1,1)
        _Glossiness("Glossiness", Range(0, 10000)) = 512
        _RimLightPower("RimLightPower", Range(0, 20)) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float3 viewDir : TEXCOORD1;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float3 viewDir : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _DiffusedColor;
            fixed4 _AmbientColor;
            fixed4 _SpecularColor;
            fixed4 _RimLightColor;
            float3 viewDir;
            float _Glossiness;
            float _RimLightPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = WorldSpaceViewDir(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float3 normalizedNormal = normalize(i.normal);
                float3 normalizedLight = normalize(_WorldSpaceLightPos0);
                float3 normalizedViewDir = normalize(i.viewDir);

                //Diffused

                float dotAngle = max(0, dot(normalizedNormal, normalizedLight));
                fixed3 diffusedLight = dotAngle * _DiffusedColor;
                fixed3 finalColor = _AmbientColor.xyz + diffusedLight;

                //Specular

                float halfVector = normalize(normalizedViewDir + normalizedLight);
                float reflectionAngle = max(0, dot(normalizedNormal, halfVector));

                float3 specularLight = _SpecularColor * pow(reflectionAngle, _Glossiness);

                //Rim Light

                float rimLight = pow((1 - saturate(dot(normalizedNormal, normalizedViewDir))), _RimLightPower);
                float4 finalRimLight = _RimLightColor * rimLight;

                //Light

                fixed3 finalLight = _AmbientColor + diffusedLight + specularLight + finalRimLight;

                return fixed4(finalLight.xyz, 1);
            }
            ENDCG
        }
    }
}
