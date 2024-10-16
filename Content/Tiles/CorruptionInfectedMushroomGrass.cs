using BiomeExpansion.Content.Waters;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomGrass : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomGrass");
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetGrass(Type, (ushort)ModContent.TileType<InfectedMushroomDirt>());
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptoomOre>()] = true;
        HitSound = SoundID.Grass;
        DustType = DustID.Corruption;
        AddMapEntry(Color.MediumPurple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.InfectedMushroomDirt>());
    }
    
    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<CorruptionInfectedMushroomWaterfallStyle>().Slot;
    }
}