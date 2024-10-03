using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Minions;

public class TestMinionBuff : ModBuff
{
    public override string Texture => "BiomeExpansion/Assets/Minions/TestMinionBuff";
    
    public override void SetStaticDefaults() {
        Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
        Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
    }

    public override void Update(Player player, ref int buffIndex) {
        if (player.ownedProjectileCounts[ModContent.ProjectileType<TestMinion>()] > 0) {
            player.buffTime[buffIndex] = 18000;
        }
        else {
            player.DelBuff(buffIndex);
            buffIndex--;
        }
    }
}