using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Buffs
{
    public class CorruptionSpawnrateDebuff : ModBuff
    {
        public override string Texture => TextureHelper.DynamicBuffsTextures["CorruptionSpawnrateDebuff"];

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }


    }
}
