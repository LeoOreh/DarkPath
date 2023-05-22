Shader "Custom/test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaveAmplitude ("WaveAmplitude", Range(0, 10)) = 2.0
        _SpeedWave ("SpeedWave", Range(0, 10)) = 1.0
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
            };

            struct v2f
           {
               float2 uv : TEXCOORD0;
               UNITY_FOG_COORDS(1)
               float4 vertex : SV_POSITION;
           };

           sampler2D _MainTex;
           float4 _MainTex_ST;
           
           half _WaveAmplitude;
           half _SpeedWave;

           v2f vert (appdata v)
           {
               v2f o;
               v.vertex.y += sin(v.vertex.z + _Time.y * _SpeedWave) * _WaveAmplitude;
               o.vertex = UnityObjectToClipPos(v.vertex);            
               o.uv = TRANSFORM_TEX(v.uv, _MainTex);
               UNITY_TRANSFER_FOG(o,o.vertex);
               return o; 
           }

           fixed4 frag (v2f i) : SV_Target
           {
               fixed4 col = tex2D(_MainTex, i.uv);
               UNITY_APPLY_FOG(i.fogCoord, col);
               return col;
           }
           ENDCG
        }       
    }
}
