using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomWoodWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomWoodWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomWoodWall>());
        Item.width = 24;
        Item.height = 24;
    }
}