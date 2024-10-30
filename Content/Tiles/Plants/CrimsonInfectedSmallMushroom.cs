using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedSmallMushroom : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedSmallMushroom"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 5);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Plants.CrimsonInfectedSmallMushroom>());
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j, 1, 1);
        return false;
    }
}