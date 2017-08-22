Shader "Custom/Dissolve" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Metallic ("Metallic", 2D) = "white" {}
		_NoiseTex ("NoiseTex (RGBA)", 2D) = "white" {}
		_NoiseRef ("NoiseRef", Range(0,1)) = 0.0
		_DissolveColor ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200	
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NoiseTex;
		sampler2D _Metallic;

		struct Input {
			float2 uv_MainTex;
		};

		half _NoiseRef;
		fixed4 _Color;
		fixed4 _DissolveColor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			fixed4 MetalTex = tex2D (_Metallic, IN.uv_MainTex) * _Color;
			o.Metallic = MetalTex.rgb;
			o.Smoothness = MetalTex.a;
			fixed4 noise = tex2D (_NoiseTex, IN.uv_MainTex);
			if( noise.r - _NoiseRef > 0 ) {
				discard;
			}
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
