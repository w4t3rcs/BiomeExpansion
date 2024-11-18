namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CrimsonInfectedMushroomSand : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CrimsonInfectedMushroomSand"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<Tiles.Sands.CrimsonInfectedMushroomSandGunProjectile>(), 10);
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CrimsonInfectedMushroomSand>());
        Item.width = 12;
        Item.height = 12;
        Item.ammo = AmmoID.Sand;
		Item.notAmmo = true;
    }
}