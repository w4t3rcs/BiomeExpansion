using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWood : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomWood");

    public override void SetStaticDefaults()
    {
        TileHelper.SetWood(Type);
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        HitSound = SoundID.Dig;
        AddMapEntry(Color.DarkCyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWood>());
    }
}