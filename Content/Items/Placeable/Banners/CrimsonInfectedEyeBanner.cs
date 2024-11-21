using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CrimsonInfectedEyeBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedEyeBanner"];

    public override int BannerTileStyle => 5;
}