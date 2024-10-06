using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedSmallMushroom : SmallMushroomTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
        TileObjectData.addTile(Type);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CrimsonInfectedSmallMushroom>(), 0, 2, 3, 4);
    }
}