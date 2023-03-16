Shader "Hidden/Slitscan"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SlitTex ("Slitscan Offset", 2D) = "white" {}
        _Scale ("Slit Scale", float) = 0.0
        _Amount ("Skew Amount", float) = 0.0
        _Speed ("Speed", float) = 0.0
        _Frames ("Frames", float) = 20
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
            sampler2D _SlitTex;
            float _Scale;
            float _Amount;
            float _Speed;
            float _Frames;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed skew = tex2D(_SlitTex, (i.uv * fixed2(1, _Scale)) + fixed2(0, round((_Time.x * _Frames) * _Speed)/_Speed)).r;
                fixed4 col = tex2D(_MainTex, i.uv + fixed2(_Amount * skew, 0));

                // just invert the colors
                //col.rgb = 1 - col.rgb;
                return col;
            }
            ENDCG
        }
    }
}
