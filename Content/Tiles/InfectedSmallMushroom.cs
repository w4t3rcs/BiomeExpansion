using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class InfectedSmallMushroom : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileCut[Type] = true;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 0);
        TileObjectData.newTile.RandomStyleRange = 5;
        TileObjectData.newTile.StyleHorizontal = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileObsidianKill[Type] = true;
        Main.tileNoFail[Type] = true;
        TileID.Sets.ReplaceTileBreakUp[Type] = true;
        TileID.Sets.IgnoredInHouseScore[Type] = true;
        TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]);
        TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
        TileObjectData.newTile.AnchorValidTiles = [
            ModContent.TileType<InfectedMushroomDirtBlock>(),
            ModContent.TileType<InfectedMushroomGrassBlock>()
        ];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        if (WorldGen.crimson)
        {
            DustType = DustID.CrimsonPlants;
            AddMapEntry(Color.Red); //Todo
        }
        else
        {
            DustType = DustID.CorruptPlants;
            AddMapEntry(Color.Purple); //Todo
        }
    }
}