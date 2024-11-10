using Terraria.DataStructures;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomCaveVines : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCaveVines"];
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetVine(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (WorldGen.genRand.NextBool() && Main.player[Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16)].cordage)
            Item.NewItem(new EntitySource_TileBreak(i, j), new Vector2(i * 16 + 8f, j * 16 + 8f), ItemID.VineRope);
    }
}