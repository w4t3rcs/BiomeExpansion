namespace BiomeExpansion.Content.Items.Others;

public class CorruptionInfectedGel : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGel"];
    
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