﻿using BiomeExpansion.Content.Backgrounds;
using BiomeExpansion.Common.Systems;
using BiomeExpansion.Content.Waters;
using Terraria.GameContent.Events;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;

namespace BiomeExpansion.Content.Biomes
{
    public class CrimsonInfectedMushroomSurfaceBiome : ModBiome
    {
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<CrimsonInfectedMushroomWaterStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Crimson;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<СrimsonInfectedMushroomSurfaceBiomeBGStyle>();
        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<СrimsonInfectedMushroomSurfaceBiomeBGUGStyle>();
        public override string BestiaryIcon => TextureHelper.DynamicBestiaryTextures["CrimsonInfectedMushroomSurfaceBiomeBestiaryIcon"];
        public override string BackgroundPath => TextureHelper.DynamicBackgroundsTextures["CrimsonInfectedMushroomSurfaceBiomeMap"];
        public override string MapBackground => TextureHelper.DynamicBackgroundsTextures["CrimsonInfectedMushroomSurfaceBiomeMap"];
        public override int BiomeCampfireItemType => ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodCampfire>();
        public override int BiomeTorchItemType => ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodTorch>();
        public override int Music => MusicID.Mushrooms;
        public override SceneEffectPriority Priority {  
            get
            {
                if (Main.LocalPlayer.ZoneDesert && Sandstorm.Happening && !(Main.LocalPlayer.ZoneSnow || Main.slimeRain || Main.eclipse)) return SceneEffectPriority.Environment; 
                return SceneEffectPriority.BiomeHigh;
            }
        }

        public override bool IsBiomeActive(Player player) {
            return !player.ZoneDungeon && ModContent.GetInstance<BiomeTileCounterSystem>().CrimsonInfectedMushroomSurfaceBiomeTileCount >= 200;
        }
        
        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (IsBiomeActive(player))
            {
                SkyManager.Instance.Activate("BiomeExpansion:CrimsonInfectedMushroomSurfaceBiome", player.position);
            }
        }
    }   
}