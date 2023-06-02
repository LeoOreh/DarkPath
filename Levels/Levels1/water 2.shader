Shader "Custom/test"
{
    Properties
    {
        _Color ("Color", Color) = (1,0,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,2)) = 0.5
        _Metallic ("Metallic", Range(0,2)) = 0.0
        _Saturation ("Saturation", Range(0,3)) = 2.0
        _IndexSin ("IndexSin", Range(0, 100)) = 6.5
        _SpeedMoveY ("SpeedMoveY", Range(0, 100)) = 2.0
        _SpeedMoveX ("SpeedMoveX", Range(0, 100)) = 2.0
        _AmplitudeY ("AmplitudeY", Range(0, 10)) = 0.05
        _AmplitudeX ("AmplitudeX", Range(0, 10)) = 0.05
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        half _IndexSin;
        half _Saturation;
        half _SpeedMoveY;
        half _SpeedMoveX;
        half _AmplitudeY;
        half _AmplitudeX;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;
            uv.y += sin(uv.x * _IndexSin + _Time.y * _SpeedMoveY) * _AmplitudeY;
            uv.x += sin(uv.y * _IndexSin + _Time.x * _SpeedMoveX) * _AmplitudeX;
            fixed4 c = tex2D (_MainTex, uv) * _Color;
            c = lerp(_Color, c , uv.x * _Saturation);
            o.Albedo = c.rgba;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
