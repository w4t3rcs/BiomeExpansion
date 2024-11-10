namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomWoodWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomWoodWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}