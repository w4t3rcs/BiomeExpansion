namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomStoneBrickWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomStoneBrickWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}