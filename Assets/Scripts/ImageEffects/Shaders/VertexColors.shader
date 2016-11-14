Shader "LazyFish_Custom/Basic/VertexColors" {
	Properties {
		_Shininess ("Shininess", Range(0.03,1)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		//LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf BlinnPhong vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		//#pragma target 3.0

		half _Shininess;
		struct Input{
			float2 uv_MainTex;
			fixed3 vertColors;
		};

		void vert (inout appdata_full v, out Input o){
			o.vertColors = v.color.rgb;
			o.uv_MainTex = v.texcoord;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = IN.vertColors.rgb;
			o.Specular = 2;
			o.Gloss = _Shininess;
		}
		ENDCG
	}
	FallBack "Specular"
}
