using BiomeExpansion.Content.Tiles.Furniture;
using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodDoor : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["InfectedMushroomWoodDoor"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<CorruptionInfectedMushroomWoodDoorClosed>());
        Item.width = 20;
        Item.height = 32;
    }
}