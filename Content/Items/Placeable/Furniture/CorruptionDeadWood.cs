using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Items.Placeable.Furniture
{
    public class CorruptionDeadWood : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionDeadWood"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionDeadWood>());
            Item.width = 12;
            Item.height = 12;
        }
    }
}
