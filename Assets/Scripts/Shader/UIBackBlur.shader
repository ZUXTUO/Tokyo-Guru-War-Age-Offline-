// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/UIBackBlur"
{
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_BlurRadius("Radius", Range(0, 10)) = 0
	}
	SubShader{
		//UGUI的RenderQueue在Transparent
		Tags{ "Queue" = "Transparent"}

		GrabPass{}

		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _GrabTexture;
			float2 _GrabTexture_TexelSize;
			float _BlurRadius;

			struct appdata {
				float4 pos:POSITION;
				float2 uv:TEXCOORD0;
				float4 color:COLOR;
			};

			struct v2f {
				float4 pos:SV_POSITION;
				float2 uv:TEXCOORD0;
				float2 uv1:TEXCOORD1;
				float2 uv2:TEXCOORD2;
				float2 uv3:TEXCOORD3;
				float2 uv4:TEXCOORD4;
				float4 color:COLOR;
			};

			v2f vert(appdata i) {
				v2f o;
				o.pos = UnityObjectToClipPos(i.pos);
				o.uv = i.uv.xy;
#if UNITY_UV_STARTS_AT_TOP
				if (_GrabTexture_TexelSize.y < 0)
					o.uv.y = 1 - o.uv.y;
#endif
				// 计算四个对角方向的UV偏移
				o.uv1 = o.uv.xy + _BlurRadius * _GrabTexture_TexelSize * float2(1, 1);
				o.uv2 = o.uv.xy + _BlurRadius * _GrabTexture_TexelSize * float2(-1, 1);
				o.uv3 = o.uv.xy + _BlurRadius * _GrabTexture_TexelSize * float2(-1, -1);
				o.uv4 = o.uv.xy + _BlurRadius * _GrabTexture_TexelSize * float2(1, -1);
				o.color = i.color;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target{
				// 中心像素的权重
				fixed4 color = tex2D(_GrabTexture, i.uv) * 0.4; // 中心权重较高
				
				// 四个对角像素的权重
				color += tex2D(_GrabTexture, i.uv1) * 0.15;
				color += tex2D(_GrabTexture, i.uv2) * 0.15;
				color += tex2D(_GrabTexture, i.uv3) * 0.15;
				color += tex2D(_GrabTexture, i.uv4) * 0.15;
				
				// 总权重为 0.4 + 4 * 0.15 = 1.0，所以无需再乘以额外的系数
				return color;
			}
			ENDCG
		}
	}
}
