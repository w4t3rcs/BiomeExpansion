using Terraria.Graphics.Effects;

namespace BiomeExpansion.Helpers;

public static class ShaderHelper
{
    public static void LoadNewShader(string shaderName, Filter filter)
    {
        Filters.Scene[shaderName] = filter;
        Filters.Scene[shaderName].Load();
    }
}