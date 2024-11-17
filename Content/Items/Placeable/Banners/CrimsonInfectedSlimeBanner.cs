using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CrimsonInfectedSlimeBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedSlimeBanner"];

    public override int BannerTileStyle => 2;
}