using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomLilyPad : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomLilyPad");

    public override void SetStaticDefaults()
    {
        TileHelper.SetLilyPad(Type);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
    
    public override bool CanPlace(int i, int j)
    {
        return Main.tile[i, j + 1] is { LiquidAmount: > 0, LiquidType: 0 } && Main.tile[i, j - 1].LiquidAmount == 0;
    }
    
    
}