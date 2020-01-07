// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34343,y:32710,varname:node_9361,prsc:2|emission-3796-OUT,custl-6436-OUT,alpha-3584-OUT,clip-3584-OUT;n:type:ShaderForge.SFN_Tex2d,id:47,x:33018,y:32731,ptovrint:False,ptlb:node_47,ptin:_node_47,varname:node_47,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b6938f7e8f4329c40aaedacb20f834c2,ntxv:0,isnm:False|UVIN-2249-UVOUT;n:type:ShaderForge.SFN_Panner,id:2249,x:32782,y:32731,varname:node_2249,prsc:2,spu:0,spv:0.1|UVIN-378-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:378,x:32346,y:32812,varname:node_378,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1667,x:33622,y:33109,varname:node_1667,prsc:2|A-4936-OUT,B-1038-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:5826,x:33743,y:32846,ptovrint:False,ptlb:node_5826,ptin:_node_5826,varname:node_5826,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1af45cacbc75a3245b2546bbd8079c97,ntxv:0,isnm:False|UVIN-1667-OUT;n:type:ShaderForge.SFN_Slider,id:2720,x:32977,y:32603,ptovrint:False,ptlb:node_2720,ptin:_node_2720,varname:node_2720,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:4936,x:33439,y:32765,varname:node_4936,prsc:2|A-2720-OUT,B-3096-OUT;n:type:ShaderForge.SFN_Tex2d,id:522,x:33018,y:32937,ptovrint:False,ptlb:node_47_copy,ptin:_node_47_copy,varname:_node_47_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:87a9c25a75c34c146b94fda20fa43750,ntxv:0,isnm:False|UVIN-1012-UVOUT;n:type:ShaderForge.SFN_Panner,id:1012,x:32800,y:32937,varname:node_1012,prsc:2,spu:0,spv:0.1|UVIN-378-UVOUT;n:type:ShaderForge.SFN_Add,id:3096,x:33267,y:32874,varname:node_3096,prsc:2|A-47-R,B-522-R;n:type:ShaderForge.SFN_Panner,id:1038,x:32734,y:33132,varname:node_1038,prsc:2,spu:0,spv:0.3|UVIN-378-UVOUT,DIST-9695-OUT;n:type:ShaderForge.SFN_Color,id:5104,x:33601,y:32699,ptovrint:False,ptlb:colour,ptin:_colour,varname:node_5104,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:3796,x:33920,y:32817,varname:node_3796,prsc:2|A-5104-RGB,B-5826-RGB;n:type:ShaderForge.SFN_ValueProperty,id:9695,x:32568,y:33210,ptovrint:False,ptlb:control,ptin:_control,varname:node_9695,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_ComponentMask,id:2919,x:33049,y:33206,varname:node_2919,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-2454-OUT;n:type:ShaderForge.SFN_Subtract,id:2803,x:33260,y:33239,varname:node_2803,prsc:2|A-2919-OUT,B-8115-OUT;n:type:ShaderForge.SFN_Vector1,id:8115,x:33084,y:33419,varname:node_8115,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:1505,x:33485,y:33220,varname:node_1505,prsc:2|IN-2803-OUT;n:type:ShaderForge.SFN_Step,id:3584,x:33659,y:33269,varname:node_3584,prsc:2|A-1505-OUT,B-8759-OUT;n:type:ShaderForge.SFN_Vector1,id:8759,x:33513,y:33393,varname:node_8759,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Multiply,id:2454,x:32903,y:33328,varname:node_2454,prsc:2|A-1038-UVOUT,B-1545-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1545,x:32672,y:33458,ptovrint:False,ptlb:delay,ptin:_delay,varname:node_1545,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:8202,x:33190,y:33520,varname:node_8202,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:5336,x:33254,y:33584,varname:node_5336,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:3764,x:33903,y:32530,ptovrint:False,ptlb:node_3764,ptin:_node_3764,varname:node_3764,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:6754,x:34083,y:32540,ptovrint:False,ptlb:node_3764_copy,ptin:_node_3764_copy,varname:_node_3764_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6436,x:34153,y:32710,varname:node_6436,prsc:2|A-3764-RGB,B-6754-A;proporder:47-5826-2720-522-5104-9695-1545-3764-6754;pass:END;sub:END;*/

Shader "Shader Forge/FlowPlus" {
    Properties {
        _node_47 ("node_47", 2D) = "white" {}
        _node_5826 ("node_5826", 2D) = "white" {}
        _node_2720 ("node_2720", Range(0, 10)) = 0
        _node_47_copy ("node_47_copy", 2D) = "white" {}
        [HDR]_colour ("colour", Color) = (0.5,0.5,0.5,1)
        _control ("control", Float ) = 5
        _delay ("delay", Float ) = 0.1
        _node_3764 ("node_3764", Color) = (0.5,0.5,0.5,1)
        _node_3764_copy ("node_3764_copy", Color) = (0.5,0.5,0.5,1)
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
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_47; uniform float4 _node_47_ST;
            uniform sampler2D _node_5826; uniform float4 _node_5826_ST;
            uniform float _node_2720;
            uniform sampler2D _node_47_copy; uniform float4 _node_47_copy_ST;
            uniform float4 _colour;
            uniform float _control;
            uniform float _delay;
            uniform float4 _node_3764;
            uniform float4 _node_3764_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 node_1038 = (i.uv0+_control*float2(0,0.1));
                float node_3584 = step(abs(((node_1038*_delay).g-0.5)),0.25);
                clip(node_3584 - 0.5);
////// Lighting:
////// Emissive:
                float4 node_5513 = _Time;
                float2 node_2249 = (i.uv0+node_5513.g*float2(0,0.1));
                float4 _node_47_var = tex2D(_node_47,TRANSFORM_TEX(node_2249, _node_47));
                float2 node_1012 = (i.uv0+node_5513.g*float2(0,0.1));
                float4 _node_47_copy_var = tex2D(_node_47_copy,TRANSFORM_TEX(node_1012, _node_47_copy));
                float2 node_1667 = ((_node_2720*(_node_47_var.r+_node_47_copy_var.r))+node_1038);
                float4 _node_5826_var = tex2D(_node_5826,TRANSFORM_TEX(node_1667, _node_5826));
                float3 emissive = (_colour.rgb*_node_5826_var.rgb);
                float3 finalColor = emissive + (_node_3764.rgb*_node_3764_copy.a);
                fixed4 finalRGBA = fixed4(finalColor,node_3584);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _control;
            uniform float _delay;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float2 node_1038 = (i.uv0+_control*float2(0,0.1));
                float node_3584 = step(abs(((node_1038*_delay).g-0.5)),0.25);
                clip(node_3584 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
