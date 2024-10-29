using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomOats : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomOats");

    public override void SetStaticDefaults()
    {
        TileHelper.SetSeaOats(Type);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}