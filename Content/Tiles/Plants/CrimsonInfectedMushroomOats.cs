using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomOats : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomOats");

    public override void SetStaticDefaults()
    {
        TileHelper.SetSeaOats(Type);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}