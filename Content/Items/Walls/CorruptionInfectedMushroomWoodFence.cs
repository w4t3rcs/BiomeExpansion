namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomWoodFence : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomWoodFence"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomWoodFence>());
        Item.width = 30;
        Item.height = 30;
    }
}