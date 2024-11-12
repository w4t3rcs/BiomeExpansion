using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiomeExpansion.Content.Items.Placeable.Gel;

namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedGelWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGelWall"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 50;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<BiomeExpansion.Content.Walls.CorruptionInfectedGelWall>());
    }

    public override void AddRecipes()
    {
        CreateRecipe(4)
            .AddIngredient<CorruptionInfectedGel>()
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}