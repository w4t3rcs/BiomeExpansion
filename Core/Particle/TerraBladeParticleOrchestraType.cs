using System;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Core.Particle;

public class TerraBladeParticleOrchestraType : IModParticleOrchestraType
{
    public void Spawn(ParticleOrchestraSettings settings, Color[] colors, int dustID, float timeToLive)
    {
		float num2 = settings.MovementVector.ToRotation() + (float)Math.PI / 2f;
		float x = 3f;
		for (float i = 0f; i < 4f; i += 1f) {
			PrettySparkleParticle prettySparkleParticle = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			Vector2 vector = ((float)Math.PI / 2f * i + num2).ToRotationVector2() * 4f;
			prettySparkleParticle.ColorTint = colors[0];
			prettySparkleParticle.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle.Rotation = vector.ToRotation();
			prettySparkleParticle.Scale = new Vector2(x, 0.5f) * 1.1f;
			prettySparkleParticle.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle.TimeToLive = timeToLive;
			prettySparkleParticle.FadeOutEnd = timeToLive;
			prettySparkleParticle.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle.AdditiveAmount = 0.35f;
			prettySparkleParticle.Velocity = -vector * 0.2f;
			prettySparkleParticle.DrawVerticalAxis = false;
			if (i % 2f == 1f) {
				prettySparkleParticle.Scale *= 1.5f;
				prettySparkleParticle.Velocity *= 2f;
			}

			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle);
		}

		for (float i = -1f; i <= 1f; i += 2f) {
			PrettySparkleParticle prettySparkleParticle2 = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			_ = num2.ToRotationVector2() * 4f;
			Vector2 vector2 = ((float)Math.PI / 2f * i + num2).ToRotationVector2() * 2f;
			prettySparkleParticle2.ColorTint = colors[1];
			prettySparkleParticle2.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle2.Rotation = vector2.ToRotation();
			prettySparkleParticle2.Scale = new Vector2(x, 0.5f) * 1.1f;
			prettySparkleParticle2.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle2.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle2.TimeToLive = timeToLive;
			prettySparkleParticle2.FadeOutEnd = timeToLive;
			prettySparkleParticle2.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle2.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle2.AdditiveAmount = 0.35f;
			prettySparkleParticle2.Velocity = vector2.RotatedBy(1.5707963705062866) * 0.5f;
			prettySparkleParticle2.DrawVerticalAxis = false;
			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle2);
		}

		for (float i = 0f; i < 4f; i += 1f) {
			PrettySparkleParticle prettySparkleParticle3 = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			Vector2 vector3 = ((float)Math.PI / 2f * i + num2).ToRotationVector2() * 4f;
			prettySparkleParticle3.ColorTint = colors[2];
			prettySparkleParticle3.LocalPosition = settings.PositionInWorld;
			prettySparkleParticle3.Rotation = vector3.ToRotation();
			prettySparkleParticle3.Scale = new Vector2(x, 0.5f) * 0.7f;
			prettySparkleParticle3.FadeInNormalizedTime = 5E-06f;
			prettySparkleParticle3.FadeOutNormalizedTime = 0.95f;
			prettySparkleParticle3.TimeToLive = timeToLive;
			prettySparkleParticle3.FadeOutEnd = timeToLive;
			prettySparkleParticle3.FadeInEnd = timeToLive / 2f;
			prettySparkleParticle3.FadeOutStart = timeToLive / 2f;
			prettySparkleParticle3.Velocity = vector3 * 0.2f;
			prettySparkleParticle3.DrawVerticalAxis = false;
			if (i % 2f == 1f) {
				prettySparkleParticle3.Scale *= 1.5f;
				prettySparkleParticle3.Velocity *= 2f;
			}

			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle3);
			for (int j = 0; j < 1; j++) {
				Dust dust = Dust.NewDustPerfect(settings.PositionInWorld, dustID, vector3.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust.noGravity = true;
				dust.scale = 0.8f;
				Dust dust2 = Dust.NewDustPerfect(settings.PositionInWorld, dustID, -vector3.RotatedBy(Main.rand.NextFloatDirection() * ((float)Math.PI * 2f) * 0.025f) * Main.rand.NextFloat());
				dust2.noGravity = true;
				dust2.scale = 1.4f;
			}
		}
    }
}