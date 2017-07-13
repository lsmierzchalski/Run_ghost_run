Shader "Hidden/Postprocess"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Tex("Tex", 2D) = "black" {}
		_Intensity("Intensity", Range(0, 1)) = 1.0
		_Flash("Flash", Range(0, 1)) = 0.0

	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _Tex;
			float _Intensity;
			float _Flash;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 screenCol = tex2D(_MainTex, i.uv);
				fixed4 scratch = tex2D(_Tex, i.uv);

				fixed4 col = 1 - screenCol;

				float2 uv = i.uv * (1.0 - i.uv.yx);   
   				float vig = uv.x * uv.y * 50.0;
    			vig = pow(vig, 0.3)-0.5; 

    			//screenCol = lerp(screenCol, screenCol * float4(0.2, 0.2, 0.0, 0.0), 0.5);
				return lerp(lerp(float4(0.075, 0.0, 0.0, 0.0), screenCol, vig), fixed4(1.0,1.0,1.0,1.0), _Flash) + scratch * 0.3;
			}
			ENDCG
		}
	}
}