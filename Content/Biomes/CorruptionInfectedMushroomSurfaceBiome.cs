using BiomeExpansion.Backgrounds;
using BiomeExpansion.Common.Systems;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
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
        public override SceneEffectPriority Priority {  
            get
            {
                if (Main.LocalPlayer.ZoneDesert && Sandstorm.Happening && !(Main.LocalPlayer.ZoneSnow || Main.slimeRain || Main.eclipse)) return SceneEffectPriority.Environment; 
                return SceneEffectPriority.BiomeHigh;
            }
        }
        
        public override bool IsBiomeActive(Player player) {
            return !player.ZoneDungeon && ModContent.GetInstance<BiomeTileCounterSystem>().CorruptionInfectedMushroomBiomeTileCount >= 150;
        }

        public override void OnInBiome(Player player)
        {
            Filters.Scene["BiomeExpansion:CorruptionInfectedMushroomShader"].Active = true;
        }

        public override void OnLeave(Player player)
        {
            Filters.Scene["BiomeExpansion:CorruptionInfectedMushroomShader"].Active = false;
        }
    }   
}