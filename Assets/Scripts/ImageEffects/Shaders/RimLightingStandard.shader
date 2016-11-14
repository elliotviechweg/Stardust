Shader "LazyFish_Custom/Basic/RimLightingStandard" {
 Properties {
     _Color ("Color", Color) = (1,1,1,1)
     _MainTex ("Albedo (RGB)", 2D) = "white" {}
     _Glossiness ("Smoothness", Range(0,1)) = 0.5
     _Metallic ("Metallic", Range(0,1)) = 0.0
     _RimColor ("Rim Color", Color) = (1,0.140625,0,1)
     _RimPower ("Rim Power", Range(0.01,8.0)) = 3
     _Emissive("Emission", 2D) = "black" {}
     _EmissiveColor("Emission Color", Color) = (1,1,1,1)
     _EmissiveIntensity("Emission Intensity", Range(0,10) ) = 1
     //_DetailMask("Detail Mask(A)",2D) ="gray"{}
     //_Detail ("Detail (RGB)", 2D) = "gray" {}          
   
 }
 SubShader {
     Tags { "RenderType"="Opaque" }
     LOD 200
     
     CGPROGRAM
     #pragma surface surf Standard fullforwardshadows
     #pragma target 3.0
     sampler2D _MainTex;    
     //sampler2D _Detail;
     //sampler2D _DetailMask;
     sampler2D _Emissive;
     
         
     
     struct Input {
         float2 uv_MainTex;
         fixed3 viewDir;
         //float2 uv_Detail;
         //float2 uv_DetailMask;             
         float2 uv_Emissive;
     };
     half _Glossiness;
     half _Metallic;
     fixed4 _Color;
     fixed4 _RimColor;
     fixed _RimPower;
     float4 _EmissiveColor;
     float _EmissiveIntensity;        
     
     void surf (Input IN, inout SurfaceOutputStandard o) {
         fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
          //fixed4 mask = tex2D(_DetailMask, IN.uv_DetailMask);
          //fixed4 detail=tex2D(_Detail,IN.uv_Detail);
          //c.rgb *= detail.rgb*2;
          o.Albedo = c.rgb;

          o.Metallic = _Metallic;
          o.Smoothness = _Glossiness;
          o.Alpha = c.a;
         
         
          float4 Tex2D1=tex2D(_Emissive,(IN.uv_Emissive.xyxy).xy);
             float4 Multiply0=Tex2D1 *_Color.xyxy;
             float4 Multiply2=Multiply0 * _EmissiveIntensity.xxxx;
          o.Emission = Multiply2 ;
            //o.Emission = (Multiply2 + _RimColor.rgb) * pow(rim, _RimPower);
          
     // Rim
         fixed3 view = normalize(IN.viewDir);
         fixed3 nml = o.Normal;
         fixed VdN = dot(view, nml);
         fixed rim = 1.0 - saturate(VdN);    

         //This comment should be remove to work RIM COLOR  
         o.Emission = (Multiply2 + _RimColor.rgb) * pow(rim, _RimPower);       
         //o.Emission = _RimColor.rgb * pow(rim, _RimPower);
         
         
         
         
     }
     ENDCG
 } 
 FallBack "Diffuse"
}



