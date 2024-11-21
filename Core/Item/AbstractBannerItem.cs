using BiomeExpansion.Content.Tiles.Banners;
using Terraria.Localization;

namespace BiomeExpansion.Core.Item;

public abstract class AbstractBannerItem : ModItem, ILocalizedModType
{
    public virtual int BannerTileStyle => 0;
    public virtual int BonusNPCID => Banners.GetBannerNPC(BannerTileStyle);    public virtual LocalizedText NPCName => NPCLoader.GetNPC(BonusNPCID).DisplayName;
    public override LocalizedText DisplayName => Language.GetOrRegister("Mods.BiomeExpansion.Items.Placeables.FormattedBannerName").WithFormatArgs(NPCName.ToString());
    public override LocalizedText Tooltip => Language.GetOrRegister("Mods.BiomeExpansion.Items.Placeables.FormattedBannerTooltip").WithFormatArgs(NPCName.ToString());
    public override void SetStaticDefaults() => ItemID.Sets.KillsToBanner[Type] = ItemID.Sets.DefaultKillsForBannerNeeded;
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Banners>(), BannerTileStyle);
        Item.width = 10;
        Item.height = 24;
        Item.rare = ItemRarityID.Blue;
        Item.value = Terraria.Item.sellPrice(silver: 2);
    }
}