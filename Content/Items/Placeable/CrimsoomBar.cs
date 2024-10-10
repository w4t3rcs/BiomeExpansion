using BiomeExpansion.Helpers;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable;

public class CrimsoomBar : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CrimsoomBar");
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        // Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CrimsoomBar>());
        Item.width = 12;
        Item.height = 12;
    }
}