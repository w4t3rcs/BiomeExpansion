using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedMushroomCaveThorns : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomCaveThorns");
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetPlantThorns(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
    }
    
    
}