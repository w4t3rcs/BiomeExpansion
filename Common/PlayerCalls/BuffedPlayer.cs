using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;

namespace BiomeExpansion.Common.PlayerCalls;

public class BuffedPlayer : ModPlayer
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