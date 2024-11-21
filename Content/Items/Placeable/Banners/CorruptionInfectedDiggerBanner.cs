using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CorruptionInfectedDiggerBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedDiggerBanner"];

    public override int BannerTileStyle => 6;
}