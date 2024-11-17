using BiomeExpansion.Core.Item;

namespace BiomeExpansion.Content.Items.Placeable.Banners;

public class CorruptionInfectedEyeBanner : AbstractBannerItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedEyeBanner"];
    
    public override int BannerTileStyle => 4;
}