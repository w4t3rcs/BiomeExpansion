using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Tiles.Furniture
{
    public class CorruptionDeadWood : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionDeadWood"];

        public override void SetStaticDefaults()
        {
            TileHelper.SetPlatform(this);
            HitSound = SoundID.Dig;
            DustType = DustID.Shadewood;
            AddMapEntry(Color.Brown);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionDeadWood>());
        }
    }
}
