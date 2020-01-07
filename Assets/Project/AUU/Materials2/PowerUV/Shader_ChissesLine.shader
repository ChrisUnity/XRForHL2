// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33237,y:32599,varname:node_9361,prsc:2|custl-3768-OUT,alpha-4597-OUT,clip-9743-OUT;n:type:ShaderForge.SFN_Tex2d,id:6891,x:32325,y:32616,ptovrint:False,ptlb:321,ptin:_321,varname:node_2769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3621-UVOUT;n:type:ShaderForge.SFN_Color,id:9942,x:32325,y:32793,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:node_493,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:1547,x:31773,y:32893,varname:node_1547,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3621,x:31995,y:32672,varname:node_3621,prsc:2,spu:0,spv:3|UVIN-1547-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:5975,x:31773,y:33135,ptovrint:False,ptlb:Slider1,ptin:_Slider1,varname:node_5406,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:3768,x:32824,y:32756,varname:node_3768,prsc:2|A-6891-RGB,B-9942-RGB;n:type:ShaderForge.SFN_Multiply,id:4597,x:33025,y:32939,varname:node_4597,prsc:2|A-92-OUT,B-9743-OUT;n:type:ShaderForge.SFN_Panner,id:522,x:31986,y:33091,varname:node_522,prsc:2,spu:0,spv:3|UVIN-1547-UVOUT,DIST-5975-OUT;n:type:ShaderForge.SFN_Multiply,id:8143,x:32153,y:33091,varname:node_8143,prsc:2|A-522-UVOUT,B-3465-OUT;n:type:ShaderForge.SFN_Subtract,id:1281,x:32495,y:33101,varname:node_1281,prsc:2|A-4383-OUT,B-7282-OUT;n:type:ShaderForge.SFN_Vector1,id:7282,x:32495,y:33251,varname:node_7282,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ComponentMask,id:4383,x:32325,y:33091,varname:node_4383,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-8143-OUT;n:type:ShaderForge.SFN_Abs,id:2290,x:32660,y:33101,varname:node_2290,prsc:2|IN-1281-OUT;n:type:ShaderForge.SFN_Step,id:9743,x:32848,y:33101,varname:node_9743,prsc:2|A-2290-OUT,B-373-OUT;n:type:ShaderForge.SFN_Vector1,id:373,x:32660,y:33251,varname:node_373,prsc:2,v1:0.25;n:type:ShaderForge.SFN_ValueProperty,id:3465,x:31986,y:33267,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_3465,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Add,id:92,x:32798,y:32881,varname:node_92,prsc:2|A-9942-A,B-6891-A;proporder:9942-5975-6891-3465;pass:END;sub:END;*/

Shader "Shader Forge/Shader_chassesline" {
    Properties {
        _Color2 ("Color2", Color) = (1,1,1,1)
        _Slider1 ("Slider1", Float ) = 0
        _321 ("321", 2D) = "white" {}
        _Thickness ("Thickness", Float ) = 0
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
            uniform sampler2D _321; uniform float4 _321_ST;
            uniform float4 _Color2;
            uniform float _Slider1;
            uniform float _Thickness;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_9743 = step(abs((((i.uv0+_Slider1*float2(0,3))*_Thickness).g-0.5)),0.25);
                clip(node_9743 - 0.5);
////// Lighting:
                float4 node_2566 = _Time + _TimeEditor;
                float2 node_3621 = (i.uv0+node_2566.g*float2(0,3));
                float4 _321_var = tex2D(_321,TRANSFORM_TEX(node_3621, _321));
                float3 finalColor = (_321_var.rgb*_Color2.rgb);
                return fixed4(finalColor,((_Color2.a+_321_var.a)*node_9743));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Slider1;
            uniform float _Thickness;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_9743 = step(abs((((i.uv0+_Slider1*float2(0,3))*_Thickness).g-0.5)),0.25);
                clip(node_9743 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
