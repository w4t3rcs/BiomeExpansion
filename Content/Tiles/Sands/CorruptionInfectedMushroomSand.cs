using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Projectile;

namespace BiomeExpansion.Content.Tiles.Sands;

public class CorruptionInfectedMushroomSand : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomSand"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetSand(this, ModContent.ProjectileType<CorruptionInfectedMushroomFallingSandProjectile>());
        Main.tileSand[Type] = false;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomHardenedSand>()] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Sands.CorruptionInfectedMushroomSand>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Purple;
        return true;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }

    public override bool HasWalkDust() {
		return Main.rand.NextBool(3);
	}

	public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color) {
		dustType = DustID.Corruption;
	}
}

public class CorruptionInfectedMushroomFallingSandProjectile : SandBallProjectile
{
    public override string Texture => TextureHelper.DynamicProjectilesTextures["CorruptionInfectedMushroomSandProjectile"];
    public override ushort SandTileType => (ushort)ModContent.TileType<CorruptionInfectedMushroomSand>();
    public override ushort SandItemType => (ushort)ModContent.ItemType<Items.Placeable.Sands.CorruptionInfectedMushroomSand>();
}

public class CorruptionInfectedMushroomSandGunProjectile : SandBallProjectile
{
    public override string Texture => TextureHelper.DynamicProjectilesTextures["CorruptionInfectedMushroomSandProjectile"];
    public override bool IsGunProjectile => true;
    public override ushort SandTileType => (ushort)ModContent.TileType<CorruptionInfectedMushroomSand>();
}