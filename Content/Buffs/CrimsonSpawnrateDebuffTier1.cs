using BiomeExpansion.Common.PlayerCalls;

namespace BiomeExpansion.Content.Buffs
{
    public class CrimsonSpawnrateDebuffTier1 : ModBuff
    {
        public override string Texture => TextureHelper.DynamicBuffsTextures["CrimsonSpawnrateDebuffTier1"];

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BuffedPlayer>().spawnRateIncrease1 = true;
        }
    }
}
