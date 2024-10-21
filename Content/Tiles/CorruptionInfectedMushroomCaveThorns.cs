using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomCaveThorns : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomCaveThorns");

    public override void SetStaticDefaults()
    {
        TileHelper.SetPlantThorns(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptionThorns;
        AddMapEntry(Color.Purple);
    }

    public override bool IsTileDangerous(int i, int j, Player player)
    {
        return true;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}