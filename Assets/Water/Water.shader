Shader "Unlit/Water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("MainColor", Color) = (1,1,1,1)
        _WaveDirectionX ("_WaveDirectionX", range(-1,1)) = 0
        _WaveDirectionZ ("_WaveDirectionZ", range(-1,1)) = -1
        _WaterSpeed ("WaterSpeed", float) = 1
        _Speed ("Speed", float) = 1
        _Frequency ("Frequency", float) = 1
        _Scale ("Scale", float) = 1
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _WaterSpeed;
            float _Speed;
            float _Frequency;
            float _Scale;
            float _WaveDirectionX;
            float _WaveDirectionZ;


            v2f vert (appdata v)
            {
                v2f o;
                half offsetVert = (v.vertex.x * _WaveDirectionX) + (v.vertex.z * _WaveDirectionZ);
                float2 waterSpeed = float2(_WaterSpeed * _WaveDirectionX, _WaterSpeed * _WaveDirectionZ);

                half value = _Scale * sin(_Time.w * _Speed + offsetVert * _Frequency);
                v.vertex.y -= value;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                o.uv = float2(o.uv.x + (_Time.x * waterSpeed.x), o.uv.y + (_Time.x * waterSpeed.y));

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col * _Color;
            }
            ENDCG
        }
    }
}
