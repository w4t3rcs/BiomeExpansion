using BiomeExpansion.Content.NPCs.Critters;
using BiomeExpansion.Content.Tiles.Sands;
using BiomeExpansion.Core.Generation;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class GiantDeadCrimsonInfectedMushroom : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["GiantDeadCrimsonInfectedMushroom"];

    public override void SetStaticDefaults()
    {
        Main.tileAxe[Type] = true;
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 5, 5, true, 5);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomSand>()];
        this.AddGenerationTileData(TileObjectData.newTile);
        TileObjectData.addTile(Type);
        MineResist = 3f;
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j, 5, 5);
        return false;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 5;
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Crimson;
        return true;
    }
}