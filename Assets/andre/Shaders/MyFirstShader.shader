// Shader "Introduction/MyFirstShader"
// {
//     Properties
//     {
//         _MainTex ("Texture", 2D) = "white" {}
//     }
//     SubShader
//     {
//         Tags { "RenderType"="Opaque" }
//         LOD 100

//         Pass
//         {
//             CGPROGRAM
//             #pragma vertex vert
//             #pragma fragment frag
//             make fog work
//             #pragma multi_compile_fog

//             #include "UnityCG.cginc"

//             struct appdata
//             {
//                 float4 vertex : POSITION;
//                 float2 uv : TEXCOORD0;
//             };

//             struct v2f
//             {
//                 float2 uv : TEXCOORD0;
//                 UNITY_FOG_COORDS(1)
//                 float4 vertex : SV_POSITION;
//             };

//             sampler2D _MainTex;
//             float4 _MainTex_ST;

//             v2f vert (appdata v)
//             {
//                 v2f o;
//                 o.vertex = UnityObjectToClipPos(v.vertex);
//                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
//                 UNITY_TRANSFER_FOG(o,o.vertex);
//                 return o;
//             }

//             fixed4 frag (v2f i) : SV_Target
//             {
//                 sample the texture
//                 fixed4 col = tex2D(_MainTex, i.uv);
//                 apply fog
//                 UNITY_APPLY_FOG(i.fogCoord, col);
//                 return col;
//             }
//             ENDCG
//         }
//     }
// }

Shader "Introduction/MyFirstShader"
{
// The Properties section of a Unity shader is used to define variables that 
// can be adjusted in the Unity Editor. These properties allow you to expose 
// shader parameters to artists and designers, making it easier to tweak and 
// customize the appearance of materials without modifying the shader code directly.

// Here’s a brief overview of what you can do with the Properties section:

// Define Adjustable Parameters: You can specify different types of properties such 
// as colors, textures, floats, vectors, and ranges. These parameters can then be 
// adjusted in the material inspector.
// Control Material Appearance: By exposing properties, you can control various 
// aspects of the material’s appearance, such as its color, texture, shininess, and more.
// User-Friendly Interface: It provides a user-friendly interface for artists 
// and designers to interact with the shader, making it easier to create and 
// fine-tune materials.

    // Data from Inpsector. Declare variables in the shader with
    // the "Var" names and correct type. E.g. 
    // sampler2D _MainTexture;
    // float4 _Color;
    Properties
    {
        // Var(UI String, Type) =  default
        _MainTexture ("Main Texture", 2D) = "white" {}
        _Color("Choose Colour", color) = (0, 1, 0, 0)
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTexture;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvs = i.uv;
                // Tile twice in the X
                // uvs.x *= 2; 
                // 7 tiles in X & Y.
                uvs *= 7; 
                // return float4(uvs, 0, 1);
                fixed4 textureColor = tex2D(_MainTexture, uvs);
                return textureColor;
            }
            ENDCG
        }
    }
}
