using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CorruptionInfectedSmallDiggerBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedDiggerBanner"];

    public override int BannerTileStyle => 6;
}