using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CorruptionInfectedSlimeBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedSlimeBanner"];

    public override int BannerTileStyle => 1;
}