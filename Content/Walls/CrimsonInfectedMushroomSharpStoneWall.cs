namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomSharpStoneWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomSharpStoneWall"];

    public override void SetStaticDefaults()
{
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}
