Shader "Graph/Point Surface" {

	Properties {
		_Smoothness("Smoothness", Range(0, 1)) = 0.5	//Making Smoothness of the material configurable.
														//Setting its range from 0-1 with default as 0.5
		
	}

	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		float _Smoothness;

		void ConfigureSurface(Input inp, inout SurfaceOutputStandard surface) {
			surface.Albedo.rg = saturate(inp.worldPos.xy * 0.5 + 0.5);
			surface.Albedo.b = 0.7;
			surface.Smoothness = _Smoothness;	
		}

		ENDCG
	}


	FallBack "Diffuse"
}