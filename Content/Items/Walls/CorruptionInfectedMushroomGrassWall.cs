namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomGrassWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomGrassWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomGrassWall>());
        Item.width = 30;
        Item.height = 30;
    }
}