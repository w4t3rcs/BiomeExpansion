using System.Collections.Generic;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Content.Skies;
using Terraria.Graphics.Effects;

namespace BiomeExpansion
{
    // Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
    public class BiomeExpansion : Mod
    {
        public override void Load()
        {
            TextureHelper.LoadDynamicTextures();
            if (Main.netMode != NetmodeID.Server)
            {
                SkyManager.Instance["BiomeExpansion:CorruptionInfectedMushroomSurfaceBiome"] = new CorruptionSky();
                SkyManager.Instance["BiomeExpansion:CrimsonInfectedMushroomSurfaceBiome"] = new CrimsonSky();
            }
        }
    }
}
