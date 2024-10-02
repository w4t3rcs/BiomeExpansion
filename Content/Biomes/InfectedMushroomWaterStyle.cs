using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes
{
    public class InfectedMushroomWaterStyle : ModWaterStyle
    {
        private Asset<Texture2D> _rainTexture;
        public override void Load()
        {
            _rainTexture = Mod.Assets.Request<Texture2D>("Content/Biomes/InfectedMushroomRain");
        }

        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<InfectedMushroomWaterSplashDust>();
        }

        public override int GetDropletGore()
        {
            return ModContent.GoreType<InfectedMushroomDroplet>();
        }
        
        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
        {
            return Color.White;
        }

        public override Asset<Texture2D> GetRainTexture()
        {
            return _rainTexture;
        }

        public override byte GetRainVariant()
        {
            return (byte) Main.rand.Next(3);
        }
    }
}