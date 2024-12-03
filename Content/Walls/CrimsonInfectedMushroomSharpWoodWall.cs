namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomSharpWoodWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomSharpWoodWall"];

    public override void SetStaticDefaults()
{
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}
