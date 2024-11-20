namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomSandWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomSandWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}