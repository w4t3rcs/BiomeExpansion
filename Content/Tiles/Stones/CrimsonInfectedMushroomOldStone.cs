using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Stones;

public class CrimsonInfectedMushroomOldStone : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomOldStone"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetStone(Type);
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomStone>()] = true;
        HitSound = SoundID.Tink;
        DustType = DustID.Crimstone;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.CrimsonInfectedMushroomOldStone>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Crimson;
        return true;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}