using BiomeExpansion.Core.Particle;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Helpers;

public static class ParticleOrchestraHelper
{
    public static readonly ParticlePool<PrettySparkleParticle> PrettySparklePool = new ParticlePool<PrettySparkleParticle>(200, GetNewPrettySparkleParticle);
    public static readonly ParticlePool<RandomizedFrameParticle> RandomizedFramePool = new ParticlePool<RandomizedFrameParticle>(200, GetNewRandomizedFrameParticle);
	public static PrettySparkleParticle GetNewPrettySparkleParticle() => new PrettySparkleParticle();
	public static RandomizedFrameParticle GetNewRandomizedFrameParticle() => new RandomizedFrameParticle();

    public static void Spawn(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, Color[] colors, int dustID, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, dustID, timeToLive);
    }

    public static void SpawnOnHit(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, NPC target, Color[] colors, int dustID, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        Vector2 positionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox);
        settings.PositionInWorld = positionInWorld;
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, dustID, timeToLive);
    }
}