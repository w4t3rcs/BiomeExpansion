using BiomeExpansion.Content.Particle;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Helpers;

public static class ParticleOrchestraHelper
{
    public static readonly ParticlePool<PrettySparkleParticle> PrettySparklePool = new ParticlePool<PrettySparkleParticle>(200, GetNewPrettySparkleParticle);

	public static PrettySparkleParticle GetNewPrettySparkleParticle() => new PrettySparkleParticle();

    public static void Spawn(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, Color[] colors, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, timeToLive);
    }

    public static void SpawnOnHit(IModParticleOrchestraType modParticleOrchestraType, int npcWhoAmI, NPC target, Color[] colors, float timeToLive = 30f, ParticleOrchestraSettings settings = default)
    {
        Vector2 positionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox);
        settings.PositionInWorld = positionInWorld;
        settings.IndexOfPlayerWhoInvokedThis = (byte)npcWhoAmI;
        modParticleOrchestraType.Spawn(settings, colors, timeToLive);
    }
}