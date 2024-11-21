using BiomeExpansion.Content.Items.Placeable.Stones;
using Terraria.GameContent.ItemDropRules;

namespace BiomeExpansion.Content.Items.Placeable.Crates;

public class CrimsonInfectedMushroomCrate : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomCrate"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 10;
        ItemID.Sets.IsFishingCrate[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Crates.CrimsonInfectedMushroomCrate>());
        Item.width = 32;
        Item.height = 34;
        Item.rare = ItemRarityID.Orange;
		Item.value = Item.sellPrice(0, 2);
    }

    public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
		itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
	}

	public override bool CanRightClick() {
		return true;
	}

	public override void ModifyItemLoot(ItemLoot itemLoot) {
		itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 4, 5, 13));
		IItemDropRule[] oreTypes = [
			ItemDropRule.Common(ModContent.ItemType<CrimsoomOre>(), 1, 4, 11),
		];
		itemLoot.Add(new OneFromRulesRule(7, oreTypes));
		IItemDropRule[] oreBars = [
			ItemDropRule.Common(ModContent.ItemType<CrimsoomBar>(), 1, 3, 7),
		];
		itemLoot.Add(new OneFromRulesRule(4, oreBars));
		IItemDropRule[] explorationPotions = [
			ItemDropRule.Common(ItemID.ObsidianSkinPotion, 1, 2, 5),
			ItemDropRule.Common(ItemID.SpelunkerPotion, 1, 2, 5),
			ItemDropRule.Common(ItemID.HunterPotion, 1, 2, 5),
			ItemDropRule.Common(ItemID.GravitationPotion, 1, 2, 5),
			ItemDropRule.Common(ItemID.MiningPotion, 1, 2, 5),
			ItemDropRule.Common(ItemID.HeartreachPotion, 1, 2, 5)
		];
		itemLoot.Add(new OneFromRulesRule(4, explorationPotions));
		IItemDropRule[] resourcePotions = [
			ItemDropRule.Common(ItemID.HealingPotion, 1, 5, 18),
			ItemDropRule.Common(ItemID.ManaPotion, 1, 5, 18),
		];
		itemLoot.Add(new OneFromRulesRule(2, resourcePotions));
		IItemDropRule[] highendBait = [
			ItemDropRule.Common(ItemID.JourneymanBait, 1, 2, 7),
			ItemDropRule.Common(ItemID.MasterBait, 1, 2, 7),
		];
		itemLoot.Add(new OneFromRulesRule(2, highendBait));
	}
}