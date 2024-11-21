using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class TerrorGhostBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["TerrorGhostBanner"];

    public override int BannerTileStyle => 3;
}