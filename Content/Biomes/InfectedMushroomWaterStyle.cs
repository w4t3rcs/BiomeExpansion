using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes
{
    public class InfectedMushroomWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return WorldGen.crimson ? DustID.Crimson : DustID.Corruption;
        }

        public override int GetDropletGore()
        {
            return ModContent.GoreType<InfectedMushroomDroplet>();
        }
        
        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1;
            g = 1;
            b = 1;
        }

        public override Color BiomeHairColor()
        {
            return Color.White;
        }

        public override Asset<Texture2D> GetRainTexture()
        {
            return Mod.Assets.Request<Texture2D>(WorldGen.crimson ? "Content/Biomes/InfectedMushroomCrimsonRain" : "Content/Biomes/InfectedMushroomCorruptionRain");
        }

        public override byte GetRainVariant()
        {
            return (byte) Main.rand.Next(3);
        }
    }
}