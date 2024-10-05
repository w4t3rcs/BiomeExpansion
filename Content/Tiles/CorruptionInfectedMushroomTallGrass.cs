using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomTallGrass : TallGrassTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomTallGrass");

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        TileObjectData.addTile(Type);
    }
}