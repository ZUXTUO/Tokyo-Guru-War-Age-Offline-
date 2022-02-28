
Shader "Custom/Box_Smooth"
{
	Properties
	{
		_MainColor("MainColor",COLOR) = (1,1,1,1)
		_MainTex("Texture", 2D) = "white" {}
		_Noise("Noise",2D) = "white"{}
		_Dissolve("Dissolve",Vector) = (0.2,0.5,0.8)
		_DissolveThread("DissolveThread",float) = 0.2
		_DissolveColor("DissolveColor",COLOR) = (1,1,1,1)
		_DissolveColFactor("_DissolveColFactor",float) = 2
		_FlyFactor("FlyFactor",float) = 3
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"
				#include "Lighting.cginc"
				struct a2v
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
					fixed3 normal : NORMAL;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 pos : SV_POSITION;
					fixed3 worldNormal : TEXCOORD1;
					fixed3 worldPos : TEXCOORD2;
					fixed3 objPos : TEXCOORD3;
				};
				sampler2D _Noise;
				sampler2D _MainTex;
				float4 _MainTex_ST;
				fixed4 _MainColor;
				fixed4 _Dissolve;
				float _DissolveThread;
				fixed4 _DissolveColor;
				float _DissolveColFactor;
				float _FlyFactor;
				v2f vert(a2v v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.worldPos = mul((float3x3)unity_ObjectToWorld,v.vertex);
					o.worldNormal = UnityObjectToWorldNormal(v.normal);
					o.objPos = v.vertex;
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.pos.xyz += v.normal * saturate(_DissolveThread - _FlyFactor) * _FlyFactor;
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					fixed3 worldNor = normalize(i.worldNormal);
					fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
					fixed4 albedo = tex2D(_MainTex, i.uv) * _MainColor;
					fixed4 noiseColor = tex2D(_Noise,i.uv);
					float factor = noiseColor.r - _DissolveThread;
					clip(factor);
					fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo.rgb;
					fixed3 diffuse = _LightColor0.rgb * albedo.rgb * (0.5 * dot(lightDir,worldNor) + 0.5);
					float lerpFactor = saturate(sign(_DissolveColFactor - factor));
					return lerp(fixed4(ambient + diffuse,1),_DissolveColor,lerpFactor);
				}
				ENDCG
			}
		}
}