using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomCattail : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomCattail");

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 15, true, 2);
        Main.tileWaterDeath[Type] = false;
        TileID.Sets.SlowlyDiesInWater[Type] = false;
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