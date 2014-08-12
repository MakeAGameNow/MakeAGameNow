Shader "Custom/Fog" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Fog {Mode  Off}
		LOD 200

		CGPROGRAM
		#pragma surface surf Lambert vertex:fogVertex finalcolor:fogColor

		sampler2D _MainTex;

		uniform half4 unity_FogColor;
		uniform half4 unity_FogStart;
		uniform half4 unity_FogEnd;
		uniform half4 unity_FogDensity;

		struct Input {
			float2 uv_MainTex;
			half fogFactor;
		};

		void fogVertex(inout appdata_full v, out Input data) 
		{
			UNITY_INITIALIZE_OUTPUT(Input, data);
			float cameraVertDist = length(mul(UNITY_MATRIX_MV, v.vertex).xyz);
			data.fogFactor = saturate((unity_FogEnd.x - cameraVertDist) / (unity_FogEnd.x - unity_FogStart.x));			
		}

		void fogColor(Input IN, SurfaceOutput o, inout fixed4 color)
		{
			color.rgb = lerp(unity_FogColor.rgb, color.rgb, IN.fogFactor);
		}

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}