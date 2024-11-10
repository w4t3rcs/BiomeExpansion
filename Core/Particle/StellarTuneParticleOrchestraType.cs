using System;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Core.Particle;

public class StellarTuneParticleOrchestraType : IModParticleOrchestraType
{
    public void Spawn(ParticleOrchestraSettings settings, Color[] colors, int dustID, float timeToLive)
    {
		float randomNumber = Main.rand.NextFloat() * ((float)Math.PI * 2f);
		float amount = 5f;
		Vector2 vector = new Vector2(0.7f);
		for (float i = 0f; i < 1f; i += 1f / amount) {
			float rotation = (float)Math.PI * 2f * i + randomNumber + Main.rand.NextFloatDirection() * 0.25f;
			Vector2 vector2 = 1.5f * vector;
			float num5 = 60f;
			Vector2 vector3 = Main.rand.NextVector2Circular(12f, 12f) * vector;
			Color colorTint = Color.Lerp(colors[0], colors[1], Main.rand.NextFloat());
			if (Main.rand.NextBool(2)) colorTint = Color.Lerp(colors[2], colors[1], Main.rand.NextFloat());

			PrettySparkleParticle prettySparkleParticle = ParticleOrchestraHelper.PrettySparklePool.RequestParticle();
			prettySparkleParticle.Velocity = rotation.ToRotationVector2() * vector2;
			prettySparkleParticle.AccelerationPerFrame = rotation.ToRotationVector2() * -(vector2 / num5);
			prettySparkleParticle.ColorTint = colorTint;
			prettySparkleParticle.LocalPosition = settings.PositionInWorld + vector3;
			prettySparkleParticle.Rotation = rotation;
			prettySparkleParticle.Scale = vector * (Main.rand.NextFloat() * 0.8f + 0.2f);
			Main.ParticleSystem_World_OverPlayers.Add(prettySparkleParticle);
		}
    }
}