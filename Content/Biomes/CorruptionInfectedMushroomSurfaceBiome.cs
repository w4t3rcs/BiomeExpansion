using BiomeExpansion.Backgrounds;
using BiomeExpansion.Common.Systems;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes
{
    public class CorruptionInfectedMushroomSurfaceBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<CorruptionInfectedMushroomWaterStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Corrupt;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<СorruptionInfectedMushroomSurfaceBiomeBGStyle>();
        public override int Music => MusicID.Mushrooms;

        public override bool IsBiomeActive(Player player) {
            return !player.ZoneDungeon && ModContent.GetInstance<BiomeTileCounterSystem>().CorruptionInfectedMushroomBiomeTileCount >= 150;
        }
        // public override void SpecialVisuals(Player player, bool isActive)
        // {
        //     player.ManageSpecialBiomeVisuals("BiomeExpansion:CorruptionInfectedMushroomSurfaceBiome:", isActive);
        // }
    }   
}