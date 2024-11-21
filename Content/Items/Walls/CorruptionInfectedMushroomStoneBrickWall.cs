namespace BiomeExpansion.Content.Items.Walls;

public class CorruptionInfectedMushroomStoneBrickWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomStoneBrickWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CorruptionInfectedMushroomStoneBrickWall>());
        Item.width = 30;
        Item.height = 30;
    }
}