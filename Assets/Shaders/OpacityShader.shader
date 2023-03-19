Shader "Custom/SimpleColor" {
    Properties {
        _Color ("Color", Color) = (1, 1, 1, 1)
        _Opacity ("Opacity", Range(0,1)) = 1
    }
 
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100
 
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct appdata {
                float4 vertex : POSITION;
            };
 
            struct v2f {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };
 
            float4 _Color;
            float _Opacity;
 
            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = _Color;
                o.color.a = _Opacity;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target {
                return i.color;
            }
            ENDCG
        }
    }
}
