using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Stones;

public class CrimsoomBar : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsoomBar"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Stones.CrimsoomBar>());
        Item.width = 12;
        Item.height = 12;
    }
}