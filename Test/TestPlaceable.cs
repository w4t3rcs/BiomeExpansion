using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Test;

public class TestPlaceable : ModItem
{
    public override string Texture => TextureHelper.GetDynamicBuffTexture("CrimsonSporeInfectionDebuff");
    
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CorruptionInfectedMushroomCaveBigMushroom>());
        Item.width = 12;
        Item.height = 12;
    }
}