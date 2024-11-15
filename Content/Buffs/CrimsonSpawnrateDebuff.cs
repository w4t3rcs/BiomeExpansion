namespace BiomeExpansion.Content.Buffs
{
    public class CrimsonSpawnrateDebuff : ModBuff
    {
        public override string Texture => TextureHelper.DynamicBuffsTextures["CrimsonSpawnrateDebuff"];

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }


    }
}
