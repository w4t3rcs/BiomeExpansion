using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CrimsonInfectedDiggerBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedDiggerBanner"];

    public override int BannerTileStyle => 7;
}