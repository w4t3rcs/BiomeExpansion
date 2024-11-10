using BiomeExpansion.Content.Backgrounds;
using BiomeExpansion.Common.Systems;
using BiomeExpansion.Content.Waters;
using Terraria.GameContent.Events;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;

namespace BiomeExpansion.Content.Biomes;

public class CorruptionInfectedMushroomSurfaceBiome : ModBiome
{
    public override ModWaterStyle WaterStyle => ModContent.GetInstance<CorruptionInfectedMushroomWaterStyle>();
    public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Corrupt;
    public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<СorruptionInfectedMushroomSurfaceBiomeBGStyle>();
    public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<СorruptionInfectedMushroomSurfaceBiomeBGUGStyle>();
    public override int BiomeCampfireItemType => ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodCampfire>();
    public override int BiomeTorchItemType => ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodTorch>();
    public override int Music => MusicID.Mushrooms;
    public override SceneEffectPriority Priority {  
        get
        {
            if (Main.LocalPlayer.ZoneDesert && Sandstorm.Happening && !(Main.LocalPlayer.ZoneSnow || Main.slimeRain || Main.eclipse)) return SceneEffectPriority.Environment; 
            return SceneEffectPriority.BiomeHigh;
        }
    }

    public override bool IsBiomeActive(Player player) {
        return !player.ZoneDungeon && ModContent.GetInstance<BiomeTileCounterSystem>().CorruptionInfectedMushroomSurfaceBiomeTileCount >= 200;
    }

    public override void SpecialVisuals(Player player, bool isActive)
    {
        if (IsBiomeActive(player))
        {
            SkyManager.Instance.Activate("BiomeExpansion:CorruptionInfectedMushroomSurfaceBiome", player.position);
        }
    }
}