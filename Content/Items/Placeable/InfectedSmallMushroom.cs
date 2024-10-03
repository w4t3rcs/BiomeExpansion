using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable;

public class InfectedSmallMushroom : ModItem
{
    public override string Texture => "BiomeExpansion/Assets/Items/Placeable/InfectedSmallMushroom";
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.InfectedSmallMushroom>());
        Item.width = 12;
        Item.height = 12;
    }
}