Shader "Custom/Toon"
{
    Properties
    {
        _MainTex("Main Texture",2D) = "while"{}                   //定义一个2D的纹理输入
        _Color1("MyColor1",Color) = (1.0,1.0,1.0,1.0)            //色阶1       
        _Color2("MyColor2",Color) = (1.0,1.0,1.0,1.0)            //色阶2
        _Line_thickness("Line_thickness",Range(0,2)) = 0.003       //线条粗细
        _Density("Density",Range(0,1)) = 0                     //控制色阶比例
    }
    SubShader
    {
            pass
            {
                //黑色描边pass
                //剔除前方，仅渲染后方
                Cull Front  

                Tags{"LightMode" = "ForWardBase"}

                CGPROGRAM
                #pragma vertex _Vert
                #pragma fragment Pixel
                //定义顶点函数输入
                struct vertexInput
                {
                    float4 Pos:POSITION;
                    float3 Normal:NORMAL;
                };
                //定义顶点函数输出
                struct vertexOutput
                {
                    float4 Pos:SV_POSITION;
                };
                //声明线宽参数
                float _Line_thickness;
                //开写顶点函数
                vertexOutput _Vert(vertexInput v)
                {
                    //声明返回值
                    vertexOutput r;
                    //计算相机与顶点的距离，准备作为顶点移位的参数
                    float4 dis = distance(_WorldSpaceCameraPos,mul(unity_ObjectToWorld, v.Pos));
                    //法线标准化
                    v.Normal = normalize(v.Normal);
                    //对顶点坐标按照法线方向移位
                    //移位距离是由外部参数_Line_thickness和相机与顶点距离dis决定的
                    v.Pos.xyz += v.Normal*dis*_Line_thickness;
                    //将移位后的顶点坐标转换到屏幕空间下
                    r.Pos = UnityObjectToClipPos(v.Pos);
                    return r;
                }

                fixed4 Pixel(vertexOutput v) :SV_TARGET
                {
                    //简单粗暴的返回黑色就行
                    return fixed4(0,0,0,0);
                }
                ENDCG
            }
            pass
            {
                //模型渲染pass
                Cull Back
                Tags{"LightMode" = "ForWardBase"}

                CGPROGRAM
                #pragma vertex _Vert
                #pragma fragment Pixel
                #include "Lighting.cginc"
                #include "UnityCG.cginc"

                struct vertexInput
                {
                    float4 Pos:POSITION;         
                    float3 Normal:NORMAL;
                    float4 texcoord : TEXCOORD0;
                };


                struct vertexOutput
                {
                    float4 Pos:SV_POSITION;
                    float3 WorldNormal : TEXCOORD0;
                    float2 uv : TEXCOORD1;
                };

                //声明我们需要的变量
                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color1;
                float4 _Color2;
                float _Density;

                vertexOutput _Vert(vertexInput v)
                {
                    vertexOutput r;
                    //将法线转换到世界坐标下，存入返回值备用
                    r.WorldNormal = UnityObjectToWorldNormal(v.Normal);
                    //将顶点的坐标信息转换到剪裁空间
                    r.Pos = UnityObjectToClipPos(v.Pos);
                    //对应纹理取得uv坐标存入返回值中备用，不过在对模型的卡通渲染中一般用不到纹理的缩放偏移
                    //所以这句代码也可以是：r.uv = v.texcoord.xy;
                    r.uv = TRANSFORM_TEX(v.texcoord,_MainTex);
                    return r;
                }

                fixed4 Pixel(vertexOutput v) :SV_TARGET
                {
                    //对MainTex进行采样，直接作为底色
                    float3 albedo = tex2D(_MainTex, v.uv).xyz;
                    //将世界坐标下的法线方向标准化
                    fixed3 WorldNormal = normalize(v.WorldNormal);
                    //将世界空间的光照方向标准化
                    fixed3 WorldLightDir = normalize(_WorldSpaceLightPos0.xyz);
                    //得到环境光
                    fixed4 ambient = fixed4(UNITY_LIGHTMODEL_AMBIENT.xyz,0);
                    //定义漫反射光
                    fixed4 diffuse;
                    //计算入射光和法线夹角的cos值，并将其作为确定光照颜色的参数与_Density参数作为比较
                    //最终确定这个点的漫反射光照颜色是哪个
                    if(saturate(dot(WorldNormal, WorldLightDir))>_Density)
                    {
                        diffuse = _Color1;
                    }
                    else
                    {
                        diffuse = _Color2;
                    }
                    //漫反射光和环境光叠加，得到总光照信息
                    fixed4 Dif = saturate(diffuse+ambient);
                    //将总的光照信息和底色进行叠底，得到最终显色返回
                    fixed4 r = fixed4(albedo, 1.0)*Dif;
                    return r;
                }
                ENDCG
            }
    }
    FallBack "Diffuse"
}