using System.Collections.Generic;
using BiomeExpansion.Content.Items.Others;
using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomTallGrass : ModTile
{
    public override string Texture => TextureHelper.DynamicTileTextures["CrimsonInfectedMushroomTallGrass"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 9);
        TileID.Sets.SwaysInWindBasic[Type] = true;
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j);
        return false;
	}
    
    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        Player player = Main.player[Player.FindClosest(new Vector2(i, j).ToWorldCoordinates(), 16, 16)];
        if (player.active)
        {
            if (player.HeldItem.type == ItemID.Sickle)
                yield return new Item(ItemID.Hay, Main.rand.Next(2, 4 + 1));
            if (Main.rand.NextBool(20))
                yield return new Item(ModContent.ItemType<CrimsonInfectedMushroomSeeds>());
        }
    }
}