using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Projectile;

namespace BiomeExpansion.Content.Tiles.Sands;

public class CrimsonInfectedMushroomSand : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomSand"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetSand(this, ModContent.ProjectileType<CrimsonInfectedMushroomFallingSandProjectile>());
        Main.tileSand[Type] = false;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomStone>()] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Sands.CrimsonInfectedMushroomSand>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Crimson;
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
		dustType = DustID.Crimson;
	}
}

public class CrimsonInfectedMushroomFallingSandProjectile : SandBallProjectile
{
    public override string Texture => TextureHelper.DynamicProjectilesTextures["CrimsonInfectedMushroomSandProjectile"];
    public override ushort SandTileType => (ushort)ModContent.TileType<CrimsonInfectedMushroomSand>();
    public override ushort SandItemType => (ushort)ModContent.ItemType<Items.Placeable.Sands.CrimsonInfectedMushroomSand>();
}

public class CrimsonInfectedMushroomSandGunProjectile : SandBallProjectile
{
    public override string Texture => TextureHelper.DynamicProjectilesTextures["CrimsonInfectedMushroomSandProjectile"];
    public override bool IsGunProjectile => true;
    public override ushort SandTileType => (ushort)ModContent.TileType<CrimsonInfectedMushroomSand>();
}