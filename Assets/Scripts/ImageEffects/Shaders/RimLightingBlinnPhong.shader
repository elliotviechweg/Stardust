Shader "LazyFish_Custom/Basic/RimLightingBlinnPhong" {
	Properties {
		_ColorTint("Tint", Color) = (1.0, 0.6, 0.6, 1.0)
		_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Glossiness ("Smoothness", Range (0.03, 1)) = 0.078125
		//_BumpMap ("Normalmap", 2D) = "bump" {}

		//_WaveAndDistance ("Wave, distance and speed", Vector) = (12, 3.6, 1, 1)
		_Cutoff ("Cutoff", float) = 0.5
		_Cutoff2 ("Cutoff2", float) = 0.5

		_RimColor("Rim Color", Color) = (1.0,1.0,1.0,1.0)
		_RimPower("Rim Power", Range(0.1,10.0)) = 5.0
	}
	 
	SubShader {
		Tags {
			"Queue" = "Geometry+200"
			"IgnoreProjector"="True"
			"RenderType"="Grass"
		}
		Cull Back
		LOD 200
		ColorMask RGB
		 
		CGPROGRAM
		#pragma surface surf BlinnPhong addshadow alphatest:_Cutoff2  //fullforwardshadows
		#pragma exclude_renderers flash
		#include "TerrainEngine.cginc"
		 
		sampler2D _MainTex;
		//sampler2D _BumpMap;
		half _Glossiness;
		fixed _Cutoff;


		struct Input {
			float2 uv_MainTex;
			//float2 uv_BumpMap;
			fixed4 color : COLOR;
	        fixed3 viewDir;
	        float2 uv_Emissive;
		};

		fixed4 _ColorTint;
		float4 _RimColor;
		float _RimPower; 	
			 
		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _ColorTint * IN.color;
			fixed4 d = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = d.a;
			clip (o.Alpha - _Cutoff);
			o.Gloss = d.a;
			o.Specular = _Glossiness;
			//o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

			//Rim
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);

		}
		ENDCG
	} 
	Fallback Off
}