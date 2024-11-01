using BiomeExpansion.Helpers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Buffs;

public class CrimsonSporeInfectionDebuff : ModBuff
{
    public override string Texture => TextureHelper.DynamicBuffsTextures["CrimsonSporeInfectionDebuff"];

    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
        Main.pvpBuff[Type] = true;
        Main.buffNoSave[Type] = true;
        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<BiomeExpansionPlayer>().isSporeInfected = true;
    }
}