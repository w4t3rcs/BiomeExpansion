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

    public class BiomeExpansionPlayer : ModPlayer
    {
        public bool isSporeInfected = false;
        public bool spawnRateIncrease1 = false;
        public bool spawnRateIncrease2 = false;

        public override void ResetEffects()
        {
            isSporeInfected = false;
            spawnRateIncrease1 = false;
            spawnRateIncrease2 = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (isSporeInfected)
            {
                Player.lifeRegenTime = 0;
                if (Main.rand.NextBool(2))
                {
                    Player.lifeRegen -= 2;
                }
            }
        }

        public override void PostUpdate()
        {
            if (Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
            {
                Player.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 60);
            }
            else if (Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
            {
                Player.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 60);
            }
        }
    }

    public class BiomeExpansionNPC : GlobalNPC // Only here to increase spawnrates for the debuffs
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<BiomeExpansionPlayer>().spawnRateIncrease1)
            {
                spawnRate -= spawnRate / 3;
                maxSpawns -= maxSpawns / 3;
            }
            else if (player.GetModPlayer<BiomeExpansionPlayer>().spawnRateIncrease2)
            {
                spawnRate -= spawnRate / 6;
                maxSpawns -= maxSpawns / 6;
            }

            if (player.GetModPlayer<BiomeExpansionPlayer>().spawnRateIncrease1)
            {
                Main.NewText(spawnRate.ToString());
            }

            //base.EditSpawnRate(player, ref spawnRate, ref maxSpawns);
        }
    }
}
