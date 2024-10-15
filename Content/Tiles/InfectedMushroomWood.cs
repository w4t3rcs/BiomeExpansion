using System.Collections.Generic;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomWood : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWood");

    public override void SetStaticDefaults()
    {
        TileHelper.SetWood(Type);
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        HitSound = SoundID.Dig;
        AddMapEntry(Color.DarkCyan);
    }

    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        if (WorldGen.crimson) return [ModContent.GetInstance<Items.Placeable.CrimsonInfectedSmallMushroom>().Item];
        return [ModContent.GetInstance<Items.Placeable.CorruptionInfectedSmallMushroom>().Item];
    }
}