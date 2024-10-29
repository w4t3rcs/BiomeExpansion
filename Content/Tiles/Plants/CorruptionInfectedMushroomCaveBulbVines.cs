using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveBulbVines : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomCaveBulbVines");

    public override void SetStaticDefaults()
    {
        TileHelper.SetVine(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.Purple);
    }
}