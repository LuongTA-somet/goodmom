Shader "Custom/Outline" {
	Properties {
		_Color ("Main Color", Vector) = (0.5,0.5,0.5,1)
		_MainTex ("Texture", 2D) = "white" {}
		_FirstOutlineColor ("Outline color", Vector) = (1,0,0,0.5)
		_FirstOutlineWidth ("Outlines width", Range(0, 2)) = 0.15
		_SecondOutlineColor ("Outline color", Vector) = (0,0,1,1)
		_SecondOutlineWidth ("Outlines width", Range(0, 2)) = 0.025
		_Angle ("Switch shader on angle", Range(0, 180)) = 89
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}