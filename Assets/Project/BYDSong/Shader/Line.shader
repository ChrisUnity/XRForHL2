// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:9361,x:33826,y:32459,varname:node_9361,prsc:2|custl-1801-OUT,alpha-984-OUT;n:type:ShaderForge.SFN_TexCoord,id:1063,x:31975,y:32747,varname:node_1063,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1669,x:32196,y:32747,varname:node_1669,prsc:2,spu:1,spv:1|UVIN-1063-UVOUT,DIST-421-OUT;n:type:ShaderForge.SFN_ComponentMask,id:324,x:32386,y:32747,varname:node_324,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-1669-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4858,x:32986,y:32802,varname:node_4858,prsc:2|A-324-OUT,B-3465-OUT;n:type:ShaderForge.SFN_Multiply,id:6009,x:32986,y:32674,varname:node_6009,prsc:2|A-422-OUT,B-3465-OUT;n:type:ShaderForge.SFN_OneMinus,id:422,x:32629,y:32747,varname:node_422,prsc:2|IN-324-OUT;n:type:ShaderForge.SFN_Slider,id:3465,x:32386,y:32673,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_2038,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.055464,max:5;n:type:ShaderForge.SFN_Multiply,id:2436,x:33165,y:32732,varname:node_2436,prsc:2|A-6009-OUT,B-4858-OUT;n:type:ShaderForge.SFN_Clamp01,id:4587,x:33321,y:32732,varname:node_4587,prsc:2|IN-2436-OUT;n:type:ShaderForge.SFN_ValueProperty,id:421,x:31975,y:32691,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_421,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Color,id:6531,x:33321,y:32560,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6531,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:984,x:33616,y:32753,varname:node_984,prsc:2|A-5507-A,B-4587-OUT;n:type:ShaderForge.SFN_Tex2d,id:5507,x:33321,y:32308,ptovrint:False,ptlb:node_5507,ptin:_node_5507,varname:node_5507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-6694-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1801,x:33558,y:32439,varname:node_1801,prsc:2|A-5507-RGB,B-6531-RGB,C-2800-OUT;n:type:ShaderForge.SFN_Vector1,id:2800,x:33321,y:32473,varname:node_2800,prsc:2,v1:2;n:type:ShaderForge.SFN_Panner,id:6694,x:32776,y:32317,varname:node_6694,prsc:2,spu:0,spv:-0.05|UVIN-1063-UVOUT;proporder:3465-421-6531-5507;pass:END;sub:END;*/

Shader "Shader Forge/Line" {
    Properties {
        _Thickness ("Thickness", Range(0, 5)) = 2.055464
        _Offset ("Offset", Float ) = 0
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _node_5507 ("node_5507", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Thickness;
            uniform float _Offset;
            uniform float4 _Color;
            uniform sampler2D _node_5507; uniform float4 _node_5507_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
				UNITY_VERTEX_OUTPUT_STEREO //Insert
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;

				UNITY_SETUP_INSTANCE_ID(v); //Insert
				UNITY_INITIALIZE_OUTPUT(VertexOutput, o); //Insert
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
				 UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i); //Insert
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
                float4 node_1487 = _Time + _TimeEditor;
                float2 node_6694 = (i.uv0+node_1487.g*float2(0,-0.05));
                float4 _node_5507_var = tex2D(_node_5507,TRANSFORM_TEX(node_6694, _node_5507));
                float3 finalColor = (_node_5507_var.rgb*_Color.rgb*2.0);
                float node_324 = (i.uv0+_Offset*float2(1,1)).g;
                float node_4587 = saturate((((1.0 - node_324)*_Thickness)*(node_324*_Thickness)));
                return fixed4(finalColor,(_node_5507_var.a*node_4587));
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
