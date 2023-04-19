// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/CelShading"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1,1,1,1)
        _AmbientColor ("Shadow Color", Color) = (0,0,0,0)

        _NoiseTex("Noise", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase"
	"PassFlags" = "OnlyDirectional" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal: NORMAL;
                float3 color: COLOR;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(1)
                float2 uv : TEXCOORD0;
                float3 worldNormal : NORMAL;
                float3 worldPos : TEXCOORD1;
                float3 color : COLOR;
                SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _BaseColor;
            float4 _AmbientColor;
            float4 _SpherePos;

            v2f vert (appdata v)
            {
                v2f o;
                //v.vertex.x += sin(v.vertex.y + _Time.y) * 0.1f;
                o.worldPos = mul (unity_ObjectToWorld, v.vertex).xyz;
                float noise = tex2Dlod(_NoiseTex, float4(o.worldPos.xz + float2(0, _Time.x/2), o.worldPos.y, 1)).r;

                
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = noise;
                UNITY_TRANSFER_FOG(o,o.vertex);
                float strength = smoothstep(0, 1, 0.5-distance(o.worldPos, _SpherePos));
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                //v.vertex.xyz += o.worldNormal * (strength * 0.001);
                v.vertex.y -= noise/20;
                //v.vertex.xyz += v.color.r * _SinTime.w;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _BaseColor;
                float3 normal = normalize(i.worldNormal);
                float shadow = SHADOW_ATTENUATION(i);
                float NdotL = dot(_WorldSpaceLightPos0, normal) * shadow;
                float lightIntensity = NdotL > 0 ? 1 : 0;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                
                //return float4(i.color, 1);
                //return fixed4(smoothstep(0, 1, 0.5-distance(i.worldPos, _SpherePos)).xxx, 1);
                return col * (_AmbientColor + lightIntensity);


            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
