using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class FearClotBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["FearClotBanner"];

    public override int BannerTileStyle => 0;
}