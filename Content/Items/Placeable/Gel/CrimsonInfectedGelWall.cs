using BiomeExpansion.Content.Tiles.Gel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Items.Placeable.Gel
{
    public class CrimsonInfectedGelWall : ModItem
    {
        public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGelWall"];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 50;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableWall(ModContent.WallType<Tiles.Gel.CrimsonInfectedGelWall>());
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient<CrimsonInfectedGel>()
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
