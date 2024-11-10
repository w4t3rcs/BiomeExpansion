namespace BiomeExpansion.Content.Items.Others;

public class CrimsonInfectedGel : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedGel"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Gel);
        Item.color = Color.White;
        Item.alpha = 15;
    }
}