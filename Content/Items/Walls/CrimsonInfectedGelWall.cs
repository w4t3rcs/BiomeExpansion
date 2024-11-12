using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiomeExpansion.Content.Items.Placeable.Gel;

namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedGelWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGelWall"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 50;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<BiomeExpansion.Content.Walls.CrimsonInfectedGelWall>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient<CrimsonInfectedGel>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
