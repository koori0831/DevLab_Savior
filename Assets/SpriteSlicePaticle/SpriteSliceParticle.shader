Shader "Custom/ParticleSpriteShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Columns ("Columns", Float) = 1
        _Rows ("Rows", Float) = 1
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float _Columns;
            float _Rows;

            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 uv : TEXCOORD0; // UV 좌표
                float4 color : TEXCOORD1;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 spriteUV : TEXCOORD1; // 조각 UV 좌표
                float4 color : COLOR0;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv.xy;
                o.color = v.color;

                float index = round(v.uv.z);
                  // 스프라이트 시트 UV 계산
                float column = fmod(index, _Columns); // 열 번호
                float row = floor(index / _Columns); // 행 번호
                float2 spriteSize = float2(1.0 / _Columns, 1.0 / _Rows); // 각 조각 크기
                o.spriteUV = v.uv * spriteSize + float2(column, row) * spriteSize;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // 각 입자마다 다른 스프라이트 조각을 샘플링
                float4 c = tex2D(_MainTex, i.spriteUV) * i.color;
                return c;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}