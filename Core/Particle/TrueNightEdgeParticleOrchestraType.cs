using System;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Core.Particle;

public class TrueNightEdgeParticleOrchestraType : IModParticleOrchestraType
{
    public void Spawn(ParticleOrchestraSettings settings, Color[] colors, int dustID, float timeToLive)
    {
		for (float i = 0f; i < 3f; i += 2f) {
			PrettySparkleParticle prettySparkleParticle = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			Vector2 vector = ((float)Math.PI / 4f + (float)Math.PI / 4f * i).ToRotationVector2() * 4f;
			prettySparkleParticle.ColorTint = colors[0];
			prettySparkleParticle.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle.Rotation = vector.ToRotation();
			prettySparkleParticle.Scale = new Vector2(4f, 1f) * 1.1f;
			prettySparkleParticle.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle.TimeToLive = timeToLive;
			prettySparkleParticle.FadeOutEnd = timeToLive;
			prettySparkleParticle.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle.AdditiveAmount = 0.35f;
			prettySparkleParticle.LocalPosition -= vector * timeToLive * 0.25f;
			prettySparkleParticle.Velocity = vector;
			prettySparkleParticle.DrawVerticalAxis = false;
			if (i == 1f) {
				prettySparkleParticle.Scale *= 1.5f;
				prettySparkleParticle.Velocity *= 1.5f;
				prettySparkleParticle.LocalPosition -= prettySparkleParticle.Velocity * 4f;
			}

			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle);
		}

		for (float i = 0f; i < 3f; i += 2f) {
			PrettySparkleParticle prettySparkleParticle = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			Vector2 vector2 = ((float)Math.PI / 4f + (float)Math.PI / 4f * i).ToRotationVector2() * 4f;
			prettySparkleParticle.ColorTint = colors[1];
			prettySparkleParticle.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle.Rotation = vector2.ToRotation();
			prettySparkleParticle.Scale = new Vector2(4f, 1f) * 0.7f;
			prettySparkleParticle.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle.TimeToLive = timeToLive;
			prettySparkleParticle.FadeOutEnd = timeToLive;
			prettySparkleParticle.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle.LocalPosition -= vector2 * timeToLive * 0.25f;
			prettySparkleParticle.Velocity = vector2;
			prettySparkleParticle.DrawVerticalAxis = false;
			if (i == 1f) {
				prettySparkleParticle.Scale *= 1.5f;
				prettySparkleParticle.Velocity *= 1.5f;
				prettySparkleParticle.LocalPosition -= prettySparkleParticle.Velocity * 4f;
			}

			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle);
			for (int j = 0; j < 2; j++) {
				Dust dust = Dust.NewDustPerfect(settings.PositionInWorld, dustID, vector2.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust.noGravity = true;
				dust.scale = 1.4f;
				Dust dust2 = Dust.NewDustPerfect(settings.PositionInWorld, dustID, -vector2.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust2.noGravity = true;
				dust2.scale = 1.4f;
			}
		}
    }
}