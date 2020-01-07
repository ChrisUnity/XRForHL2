Shader "Unlit/uvMove"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	    _SecondTex("Texture",2D)="white"{}
		_MaskTex("Texture",2D) = "white"{}
		_Color("Color", Color) = (0.5,0.5,0.5,1)
	}
	SubShader
	{
		Tags { "QUEUE" = "Transparent+10" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
		Blend  SrcAlpha OneMinusSrcAlpha  //设置blend 计算方式  
		Pass
		{
		Tags{ "QUEUE" = "Transparent+10" "IGNOREPROJECTOR" = "true" "RenderType" = "Transparent" "PreviewType" = "Plane" }
		ZWrite Off
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
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
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _SecondTex;
			sampler2D _MaskTex;
			float4 _MainTex_ST;
			uniform float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col1 = tex2D(_MainTex, i.uv);
			
				fixed4 col3 = tex2D(_MaskTex, i.uv);
				i.uv.y += sin(i.uv.x +_Time.y);
				fixed4 col2 = tex2D(_SecondTex, i.uv);
				fixed4 col = col1 + (col2*col3.a)*_Color;
				return col;
			}
			ENDCG
		}
	}
}
