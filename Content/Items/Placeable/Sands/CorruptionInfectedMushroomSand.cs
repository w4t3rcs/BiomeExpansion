namespace BiomeExpansion.Content.Items.Placeable.Sands;

public class CorruptionInfectedMushroomSand : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomSand"];

    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<Tiles.Sands.CorruptionInfectedMushroomSandGunProjectile>(), 10);
    }

    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Sands.CorruptionInfectedMushroomSand>());
        Item.width = 12;
        Item.height = 12;
        Item.ammo = AmmoID.Sand;
		Item.notAmmo = true;
    }
}