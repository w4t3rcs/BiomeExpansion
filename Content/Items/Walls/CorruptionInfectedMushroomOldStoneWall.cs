namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomOldStoneWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomOldStoneWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomOldStoneWall>());
        Item.width = 30;
        Item.height = 30;
    }
}