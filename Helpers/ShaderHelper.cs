using Terraria.Graphics.Effects;

namespace BiomeExpansion.Helpers;

public static class ShaderHelper
{
    /// <summary>
    /// Loads a new shader to the Scene filter collection.
    /// <param name="shaderName">The name of the shader. Must be unique.</param>
    /// <param name="filter">The filter to load. Typically a <see cref="Filter"/></param>
    /// </summary>
    public static void LoadNewShader(string shaderName, Filter filter)
    {
        Filters.Scene[shaderName] = filter;
        Filters.Scene[shaderName].Load();
    }
}