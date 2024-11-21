namespace BiomeExpansion.Content.Items.Walls;

public class CrimsonInfectedMushroomStoneBrickWall : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomStoneBrickWall"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableWall(ModContent.WallType<Content.Walls.CrimsonInfectedMushroomStoneBrickWall>());
        Item.width = 30;
        Item.height = 30;
    }
}