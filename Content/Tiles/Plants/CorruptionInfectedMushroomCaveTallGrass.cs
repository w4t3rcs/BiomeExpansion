using System.Collections.Generic;
using BiomeExpansion.Content.Items.Others;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Generation;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveTallGrass : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveTallGrass"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 16, true, 2, 1);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomStone>(), ModContent.TileType<CorruptionInfectedMushroomOldStone>()];
        this.AddGenerationTileData(TileObjectData.newTile);
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

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j, 1, 2);
        return false;
	}
}