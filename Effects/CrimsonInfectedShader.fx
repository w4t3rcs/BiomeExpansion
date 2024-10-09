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
    color.r *= 1.5; 
    color.g *= 0.2; 
    color.b *= 0.2;

    float wave = sin((input.TexCoord.x + input.TexCoord.y) * 25.0 + Time * 6.0) * 0.03;
    float2 distortedTexCoord = input.TexCoord + wave * Intensity;

    float4 distortedColor = tex2D(SpriteTexture, distortedTexCoord);

    color = lerp(color, distortedColor, 0.5);

    float2 center = float2(0.5, 0.5);
    float dist = distance(input.TexCoord, center);
    color.rgb *= 1.0 - dist * 0.4 * Intensity;

    return color;
}

technique CrimsonEffect
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 MainPS();
    }
}