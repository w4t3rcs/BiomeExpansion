namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedMushroomStoneWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomStoneWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CrimsonInfectedMushroomStoneWall>());
        Item.width = 30;
        Item.height = 30;
    }
}