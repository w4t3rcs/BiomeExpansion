using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedSmallMushroom : InfectedSmallMushroomTile
{
    public override string Texture => TextureUtil.GetDynamicTileTexture("CorruptionInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrassBlock>()];
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        TileObjectData.addTile(Type);
    }
}