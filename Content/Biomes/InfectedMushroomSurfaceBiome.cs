using BiomeExpansion.Backgrounds;
using BiomeExpansion.Common.Systems;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes
{
    public class InfectedMushroomSurfaceBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<InfectedMushroomWaterStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Mushroom;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<InfectedMushroomSurfaceBiomeBGStyle>();
        public override int Music => MusicID.Mushrooms;

        public override bool IsBiomeActive(Player player) {
            return !player.ZoneDungeon && ModContent.GetInstance<BiomeTileCounterSystem>().InfectedMushroomBiomeTileCount >= 950;
        }
    }   
}