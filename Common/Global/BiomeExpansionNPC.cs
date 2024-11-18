using BiomeExpansion.Common.PlayerCalls;

namespace BiomeExpansion.Common.Global;

public class BiomeExpansionNPC : GlobalNPC
{
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
    {
        if (player.GetModPlayer<BuffedPlayer>().spawnRateIncrease1)
        {
            spawnRate -= spawnRate / 3;
            maxSpawns -= maxSpawns / 3;
        }
        else if (player.GetModPlayer<BuffedPlayer>().spawnRateIncrease2)
        {
            spawnRate -= spawnRate / 6;
            maxSpawns -= maxSpawns / 6;
        }
    }
}