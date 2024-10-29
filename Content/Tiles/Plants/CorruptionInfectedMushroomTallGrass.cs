using System.Collections.Generic;
using BiomeExpansion.Content.Items.Others;
using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomTallGrass : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomTallGrass");

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 9);
        TileID.Sets.SwaysInWindBasic[Type] = true;
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }
    
    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        Player player = Main.player[Player.FindClosest(new Vector2(i, j).ToWorldCoordinates(), 16, 16)];
        if (player.active)
        {
            if (player.HeldItem.type == ItemID.Sickle)
                yield return new Item(ItemID.Hay, Main.rand.Next(2, 4 + 1));
            if (Main.rand.NextBool(20))
                yield return new Item(ModContent.ItemType<CorruptionInfectedMushroomSeeds>());
        }
    }
}