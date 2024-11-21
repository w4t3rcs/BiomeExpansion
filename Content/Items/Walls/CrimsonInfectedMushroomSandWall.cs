namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedMushroomSandWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomSandWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CrimsonInfectedMushroomSandWall>());
        Item.width = 30;
        Item.height = 30;
    }
}