Shader "Gondr/Shader19"
{
    Properties
    {        
        [NoScaleOffset] _TextureA("CameraSortingLayerTexture", 2D) = "white" {}
        _Duration("Duration", Float) = 3
        _StartTime("StartTime", Float) = 0
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
            
            struct v2f
            {
                float4 vertex: SV_POSITION;  //위치
                float2 uv: TEXCOORD0;
                float4 position: TEXCOORD1;  //커스텀 데이터
                float4 screenPos: TEXCOORD2;
            };
    
            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.position = v.vertex;
                o.uv = v.texcoord;
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            sampler2D _TextureA;
            float _Duration;
            float _StartTime;

            
            
            fixed4 frag (v2f i) : COLOR
            {
                
                float time = _Time.y - _StartTime; //현재시간에서 시작시간을 뺀 시간을 Time으로
                float2 pt = -1.0 + 2.0 * i.uv; // 0 ~ 2까지의 값에다가 -1을 해줘서 -1 ~ 1까지로 변경
                float len = length(pt);
                float2 ripple = i.uv + (pt / len) * cos(len * 40 - time * 10) * 0.02;
                float delta  = clamp(time / _Duration, 0, 1.0);
            
                float2 uv = lerp(ripple, i.uv, clamp(len, 0 , 1));
            
                fixed3 color_a = tex2D(_TextureA, uv).rgb;
                return fixed4( color_a, 1.0 );
            }
            ENDCG
        }
    }
}
