Shader "GradientSkybox/Linear/Multiple Color" {
	Properties {
		_RampTex ("Ramp Texture", 2D) = "white" {}
		_Up ("Up", Vector) = (0,1,0,1)
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	//CustomEditor "GradientSkybox.LinearMultipleColorGradientSkyboxGUI"
}