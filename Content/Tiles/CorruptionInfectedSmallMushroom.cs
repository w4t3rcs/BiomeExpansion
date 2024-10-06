using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedSmallMushroom : SmallMushroomTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedSmallMushroom");

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        TileObjectData.addTile(Type);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CorruptionInfectedSmallMushroom>(), 0, 2, 3, 4);
    }
}