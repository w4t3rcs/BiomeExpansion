namespace BiomeExpansion.Content.Items.Fishes;

public class CrimsonInfectedMushroomFish : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomFish"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 3;
        ItemID.Sets.CanBePlacedOnWeaponRacks[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 34;
        Item.maxStack = 9999;
        Item.rare = ItemRarityID.Blue;
        Item.value = Item.sellPrice(silver: 7);
    }

    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
    {
        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Fish;
    }
}