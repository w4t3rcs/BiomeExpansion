using System;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Content.Particle;

public class XParticleOrchestraType : IModParticleOrchestraType
{
    public void Spawn(ParticleOrchestraSettings settings, Color[] colors, float timeToLive)
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
			PrettySparkleParticle prettySparkleParticle2 = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			Vector2 vector2 = ((float)Math.PI / 4f + (float)Math.PI / 4f * i).ToRotationVector2() * 4f;
			prettySparkleParticle2.ColorTint = colors[1];
			prettySparkleParticle2.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle2.Rotation = vector2.ToRotation();
			prettySparkleParticle2.Scale = new Vector2(4f, 1f) * 0.7f;
			prettySparkleParticle2.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle2.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle2.TimeToLive = timeToLive;
			prettySparkleParticle2.FadeOutEnd = timeToLive;
			prettySparkleParticle2.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle2.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle2.LocalPosition -= vector2 * timeToLive * 0.25f;
			prettySparkleParticle2.Velocity = vector2;
			prettySparkleParticle2.DrawVerticalAxis = false;
			if (i == 1f) {
				prettySparkleParticle2.Scale *= 1.5f;
				prettySparkleParticle2.Velocity *= 1.5f;
				prettySparkleParticle2.LocalPosition -= prettySparkleParticle2.Velocity * 4f;
			}

			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle2);
			for (int j = 0; j < 2; j++) {
				Dust dust = Dust.NewDustPerfect(settings.PositionInWorld, 75, vector2.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust.noGravity = true;
				dust.scale = 1.4f;
				Dust dust2 = Dust.NewDustPerfect(settings.PositionInWorld, 75, -vector2.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust2.noGravity = true;
				dust2.scale = 1.4f;
			}
		}
    }
}