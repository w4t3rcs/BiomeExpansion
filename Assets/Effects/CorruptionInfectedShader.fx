float Time : register(C0);
float Intensity : register(C1);

sampler2D SpriteTexture : register(s0);

struct PS_INPUT
{
    float2 TexCoord : TEXCOORD0;
};

float4 MainPS(PS_INPUT input) : COLOR
{
    float4 color = tex2D(SpriteTexture, input.TexCoord);
    color.r *= 0.4;
    color.g *= 0.2;
    color.b *= 2.0;
    float wave = sin((input.TexCoord.x + input.TexCoord.y) * 30.0 + Time * 8.0) * 0.05;
    float2 distortedTexCoord = input.TexCoord + wave * Intensity;
    float4 distortedColor = tex2D(SpriteTexture, distortedTexCoord);
    color = lerp(color, distortedColor, 0.6);
    float2 center = float2(0.5, 0.5);
    float dist = distance(input.TexCoord, center);
    color.rgb *= 1.0 - dist * 0.5 * Intensity;
    return color;
}

technique CorruptionInfectedShader
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 MainPS();
    }
}