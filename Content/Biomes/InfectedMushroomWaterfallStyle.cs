using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes
{
    public class InfectedMushroomWaterfallStyle : ModWaterfallStyle
    {
        public override string Texture => "BiomeExpansion/Assets/Water/InfectedMushroomWaterfallStyle";
        
        public override void AddLight(int i, int j)
        {
            Color color = WorldGen.crimson ? Color.Crimson : Color.Purple;
            Lighting.AddLight(new Vector2(i, j).ToWorldCoordinates(), color.ToVector3() * 0.5f);
        }
    }
}