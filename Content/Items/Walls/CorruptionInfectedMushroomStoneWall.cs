namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomStoneWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomStoneWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomStoneWall>());
        Item.width = 30;
        Item.height = 30;
    }
}