namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedMushroomGrassWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomGrassWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CrimsonInfectedMushroomGrassWall>());
        Item.width = 30;
        Item.height = 30;
    }
}