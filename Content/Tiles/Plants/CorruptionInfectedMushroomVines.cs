using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Core.Generation;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomVines : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomVines"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetVine(Type);
        GenerationTileData.ValidTiles.Add(Type, [ModContent.TileType<CorruptionInfectedMushroomGrass>()]);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.Purple);
    }
    
    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (WorldGen.genRand.NextBool() && Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].cordage)
            Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16 + 8f, j * 16 + 8f), ItemID.VineRope);
    }
}