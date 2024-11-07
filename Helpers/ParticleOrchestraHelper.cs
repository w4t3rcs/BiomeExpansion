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

    /// <summary>
    /// Spawns a particle orchestra effect using the specified particle orchestra type.
    /// </summary>
    /// <param name="modParticleOrchestraType">The type of particle orchestra to spawn.</param>
    /// <param name="npcWhoAmI">The index of the NPC who invoked the particle effect.</param>
    /// <param name="colors">An array of colors to be used for the particles.</param>
    /// <param name="dustID">The ID of the dust to be used for the particles.</param>
    /// <param name="timeToLive">The time in ticks for which the particles should remain active. Default is 30.</param>
    /// <param name="settings">Additional settings for the particle orchestra. Default is uninitialized.</param>
    public static void Spawn(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, Color[] colors, int dustID, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, dustID, timeToLive);
    }

    /// <summary>
    /// Spawns a particle orchestra effect at the location of the specified NPC.
    /// </summary>
    /// <param name="modParticleOrchestraType">The type of particle orchestra to spawn.</param>
    /// <param name="npcWhoAmI">The index of the NPC who invoked the particle effect.</param>
    /// <param name="target">The NPC at whose location the particle orchestra should be spawned.</param>
    /// <param name="colors">An array of colors to be used for the particles.</param>
    /// <param name="dustID">The ID of the dust to be used for the particles.</param>
    /// <param name="timeToLive">The time in ticks for which the particles should remain active. Default is 30.</param>
    /// <param name="settings">Additional settings for the particle orchestra. Default is uninitialized.</param>
    public static void SpawnOnHit(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, NPC target, Color[] colors, int dustID, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        Vector2 positionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox);
        settings.PositionInWorld = positionInWorld;
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, dustID, timeToLive);
    }
}