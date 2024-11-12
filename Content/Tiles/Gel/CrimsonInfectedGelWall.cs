using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Tiles.Gel
{
    public class CrimsonInfectedGelWall : ModWall
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedGelWall"];

        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;

            DustType = DustID.Crimson;

            AddMapEntry(Color.Crimson);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
