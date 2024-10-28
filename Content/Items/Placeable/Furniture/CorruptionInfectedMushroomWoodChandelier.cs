using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodChandelier : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptionInfectedMushroomWoodChandelier");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CorruptionInfectedMushroomWoodChandelier>());
        Item.width = 34;
        Item.height = 36;
    }
}