namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedMushroomOldStoneWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomOldStoneWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CrimsonInfectedMushroomOldStoneWall>());
        Item.width = 30;
        Item.height = 30;
    }
}