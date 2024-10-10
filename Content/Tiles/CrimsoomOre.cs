using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CrimsoomOre : InfectedMushroomStoneTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsoomOre");

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        DustType = DustID.Crimstone;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CrimsoomOre>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Crimson;
        return true;
    }
}