using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedSmallMushroom : InfectedSmallMushroomTile
{
    public override string Texture => TextureUtil.GetDynamicTileTexture("CrimsonInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrassBlock>()];
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
        TileObjectData.addTile(Type);
    }
}