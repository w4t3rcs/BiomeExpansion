using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Common.Dtos;

public abstract class SmallMushroomTile : ModTile
{
    public override void SetStaticDefaults()
    {
        const int height = 1;
        Main.tileLighted[Type] = true;
        Main.tileCut[Type] = true;
        Main.tileLavaDeath[Type] = false;
        Main.tileObsidianKill[Type] = true;
        Main.tileNoFail[Type] = true;
        TileID.Sets.ReplaceTileBreakUp[Type] = true;
        TileID.Sets.IgnoredInHouseScore[Type] = true;
        TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.CoordinateHeights = new int[height];
        TileObjectData.newTile.CoordinateHeights[0] = 16;
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.Origin = new Point16(1 / 2, height - 1);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        HitSound = SoundID.Grass;
    }
}