using BiomeExpansion.Common.Utils;
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
            if (WorldGen.crimson)
            {
                ColorUtil.SetRGBFromColor(out r, out g, out b, Color.Crimson);
            }
            else
            {
                ColorUtil.SetRGBFromColor(out r, out g, out b, Color.Purple);
            }
        }

        public override Color BiomeHairColor()
        {
            return WorldGen.crimson ? Color.Crimson : Color.Purple;
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