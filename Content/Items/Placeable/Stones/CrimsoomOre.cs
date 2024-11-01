using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CrimsoomOre : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsoomOre"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CrimsoomOre>());
        Item.width = 12;
        Item.height = 12;
    }
}