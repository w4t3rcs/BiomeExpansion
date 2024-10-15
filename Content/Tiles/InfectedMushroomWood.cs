using System.Collections.Generic;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomWood : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWood");

    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        Main.tileBlockLight[Type] = true;
        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Wood"]);
        HitSound = SoundID.Dig;
        AddMapEntry(Color.DarkCyan);
    }

    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        if (WorldGen.crimson) return [ModContent.GetInstance<Items.Placeable.CrimsonInfectedSmallMushroom>().Item];
        return [ModContent.GetInstance<Items.Placeable.CorruptionInfectedSmallMushroom>().Item];
    }
}