namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomSandWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomSandWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomSandWall>());
        Item.width = 30;
        Item.height = 30;
    }
}