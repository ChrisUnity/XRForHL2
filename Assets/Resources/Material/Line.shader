// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "AngryBots/FX/LaserScope" {
    Properties{
        _MainTex("MainTex", 2D) = "white"
        _NoiseTex("NoiseTex", 2D) = "white"
    }
        CGINCLUDE //CGINCLUDE .. ENDCG包起代码块，会自动编译进pass()中
#include "UnityCG.cginc"//包含TRANSFORM_TEX等函数
        sampler2D _MainTex;
    sampler2D _NoiseTex;
    half4 _MainTex_ST;//对应TRANSFORM_TEX
    half4 _NoiseTex_ST;//对应TRANSFORM_TEX
    fixed4 _TintColor;
    struct vf {
        half4 pos : SV_POSITION; 【1】
            half4 uv : TEXCOORD0;
    };

    vf vert(appdata_full v)//appdata_full:带有位置、法线、切线、顶点色和两个纹理坐标的顶点着色器输入{
        vf o;

    o.pos = UnityObjectToClipPos(v.vertex);//UNITY_MATRIX_MVP:当前模型视图投影矩阵,将vertex投影到视口，返回对应视口坐标
   //TRANSFORM_TEX(v.texcoord, _MainTex) 等价 v.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw
    o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
    o.uv.zw = TRANSFORM_TEX(v.texcoord, _NoiseTex);//分别用xy,zw存储MainTex,NoiseTex的uv
    return o;
}

fixed4 frag(vf i) : COLOR{
    return tex2D(_MainTex, i.uv.xy) * tex2D(_NoiseTex, i.uv.zw);//MainTex,NoiseTex混合
}

ENDCG

SubShader {
    Tags{ "RenderType" = "Transparent" "Reflection" = "LaserScope" "Queue" = "Transparent" }// "Reflection"??
        Cull Off//设置多边形剔除模式CullOff 关闭阴影面剔除 Cull Back 剔除背面 CullFront 剔除正面 ：激光存在透明模块，既使背景被激光遮挡，也不应该剔除
        ZWrite Off//设置深度写模式
        Blend SrcAlpha One//设置alpha混合模式（贴图颜色值rgb * Alpha值）+（背景颜色rgb * 1）//(0.8,0,1)与结果不符
        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma fragmentoption ARB_precision_hint_fastest
            ENDCG
    }
}
FallBack Off

}