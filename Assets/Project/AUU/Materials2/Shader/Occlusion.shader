///
/// Basic occlusion shader that can be used with spatial mapping meshes.
/// No pixels will be rendered at the object's location.
///
Shader "HoloToolkit/Occlusion"
{
    Properties
    {
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry-1"
        }

        Pass
        {
           ColorMask 0 // Color will not be rendered.
            //Offset 50, 100

            CGPROGRAM
            #pragma vertex vert
           #pragma fragment frag

            // We only target the HoloLens (and the Unity editor), so take advantage of shader model 5.
            #pragma target 3.0
           // #pragma only_renderers d3d11

            #include "UnityCG.cginc"
		    struct appdata
           {
	          UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
            };
            struct v2f
            {
                float4 pos : SV_POSITION;
         
			    UNITY_VERTEX_OUTPUT_STEREO //Insert
            };

            v2f vert(appdata_base v)
            {
                UNITY_SETUP_INSTANCE_ID(v);
                v2f o;
				UNITY_SETUP_INSTANCE_ID(v); //Insert
				UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                return o;
            }
			//UNITY_DECLARE_SCREENSPACE_TEXTURE(_MainTex); //Insert
            half4 frag(v2f i) : COLOR
            {
				   UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //Insert

	              // fixed4 col = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_MainTex, i.uv); //Insert
                return float4(1,1,1,1);
            }
            ENDCG
        }
    }
}