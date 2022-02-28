// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/moveLight" 
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" {}
        _FlowColor("Flow Color", Color) = (1,1,1,1)
        _FlowRange("Flow Range", Float) = 0.01
    }

        SubShader{


            Pass
            {

            Tags {   "Queue" = "Geometry" }

            CGPROGRAM

            #include "UnityCG.cginc"

            struct v2f
            {
                float4 vertex:POSITION;
                float2 uv:TEXCOORD0;
                float nr : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _FlowColor;
            float _FlowRange;

            v2f vert(appdata_base  v)
            {

                v2f o;
                o.uv = v.texcoord;
                o.vertex = UnityObjectToClipPos(v.vertex);
                float2 dir = normalize(float2(cos(_Time.y),sin(_Time.y)));
                float2 worldNormal = normalize(mul((float3x3)unity_ObjectToWorld,v.normal)).xz;

                o.nr = dot(dir,worldNormal);


                return o;
            }

            fixed4 frag(v2f IN) :COLOR
            {
                //fixed4  c = tex2D(_MainTex, IN.uv);
                fixed fac = saturate(sign(IN.nr * (IN.nr - _FlowRange)));
                fixed4 c = fac * tex2D(_MainTex, IN.uv) + (1 - fac) * _FlowColor;
                return c;
            }

            #pragma vertex vert
            #pragma fragment frag

            ENDCG
            }


        }
            FallBack "Diffuse"
}

/*
{
    Properties
    {
        //������  
        _MainTex("Texture", 2D) = "white" {}
    //�ƹ�����  
    _LightTex("Light Texture",2D) = "white"{}
    //��������  
    _MaskTex("Mask Texture",2D) = "white"{}
    }
        SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100
        //͸�����  
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _LightTex;
            sampler2D _MaskTex;
            fixed4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //�ƹ���ͼ ȡһ��UV  
                float2 uv = i.uv * 0.5;
                //���ϸı�uv��x�ᣬ������x�᷽���ƶ�,_TimeΪshader��ʱ�亯������һֱִ��  
                uv.x += -_Time.y * 0.4;
                //ȡ�ƹ���ͼ��alphaֵ,��ɫΪ0����ɫΪ1   
                fixed lightTexA = tex2D(_LightTex,uv).a;
                //��ȡ������ͼ��alphaֵ����ɫΪ0����ɫΪ1 �����uv�������uv�ǵ��õĲ�һ���ĺ���  
                fixed maskA = tex2D(_MaskTex,i.uv).a;

                //������+�ƹ���ͼ*������ͼ ��ԭ���κ���*0Ϊ0   �����ͱ�������������ֲ�Э���ƹ���ͼ  
                fixed4 col = tex2D(_MainTex, i.uv) + lightTexA * maskA * 0.5;
                // apply fog  
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
*/