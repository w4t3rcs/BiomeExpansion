using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedSmallMushroom : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedSmallMushroom");
    private static readonly string GlowMaskTexture = TextureHelper.GetDynamicTileTexture("CorruptionInfectedSmallMushroomGlow");

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 5);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Plants.CorruptionInfectedSmallMushroom>());
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, GlowMaskTexture, i, j, 1, 1);
        return false;
    }
}