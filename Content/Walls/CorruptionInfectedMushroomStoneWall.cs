namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomStoneWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomStoneWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.Conversion.Stone[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}