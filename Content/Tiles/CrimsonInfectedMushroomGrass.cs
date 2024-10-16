using BiomeExpansion.Content.Waters;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedMushroomGrass : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomGrass");
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetGrass(Type, (ushort)ModContent.TileType<InfectedMushroomDirt>());
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsoomOre>()] = true;
        HitSound = SoundID.Grass;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.InfectedMushroomDirt>());
    }
    
    
    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<CrimsonInfectedMushroomWaterfallStyle>().Slot;
    }
}