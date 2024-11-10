namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomGrassWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomGrassWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}