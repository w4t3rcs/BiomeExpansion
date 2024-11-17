using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class SmallTerrorGhostBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["TerrorGhostBanner"];

    public override int BannerTileStyle => 3;
}