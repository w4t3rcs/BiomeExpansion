namespace BiomeExpansion.Core.Projectile;

public abstract class SandBallProjectile : ModProjectile
{
    public virtual bool IsGunProjectile => false;
    public virtual ushort SandTileType => 0;
    public virtual ushort SandItemType => 0;

    public override void SetStaticDefaults() {
		ProjectileID.Sets.FallingBlockDoesNotFallThroughPlatforms[Type] = true;
		ProjectileID.Sets.ForcePlateDetection[Type] = true;
        ProjectileID.Sets.FallingBlockTileItem[Type] = IsGunProjectile ? new(SandTileType) : new(SandTileType, SandItemType);
    }

    public override void SetDefaults()
    {
        if (IsGunProjectile)
        {
            Projectile.CloneDefaults(ProjectileID.EbonsandBallGun);
			AIType = ProjectileID.EbonsandBallGun;
        }
        else
        {
            Projectile.CloneDefaults(ProjectileID.EbonsandBallFalling);
        }
    }
}