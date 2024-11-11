using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Items.Placeable.Gel
{
    public class CorruptionInfectedGelWall : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGelWall"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 50;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Tiles.Gel.CorruptionInfectedGelWall>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient<CorruptionInfectedGel>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
