Shader "Unlit/Phong"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DiffusedColor("DiffusedColor", color) = (1,1,1,1)
        _AmbientColor("AmbientColor", color) = (1,1,1,1)
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _DiffusedColor;
            fixed4 _AmbientColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                //return col * _Color;
                float3 normalizedNormal = normalize(i.normal);
                float3 normalizedLight = normalize(_WorldSpaceLightPos0);
                float dotAngle = dot(normalizedNormal, normalizedLight);
                dotAngle = max(dotAngle, 0);

                fixed3 diffusedLight = dotAngle * _DiffusedColor;
                fixed3 finalColor = _AmbientColor.xyz + diffusedLight;

                return fixed4(finalColor.xyz, 1);
            }
            ENDCG
        }
    }
}
