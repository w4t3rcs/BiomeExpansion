using System;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;

namespace BiomeExpansion.Core.Particle;

public class BlackLightningHitParticleOrchestraType : IModParticleOrchestraType
{
    public void Spawn(ParticleOrchestraSettings settings, Color[] colors, int dustID, float timeToLive)
    {
		float num = Main.rand.NextFloat() * ((float)Math.PI * 2f);
		float amount = 7f;
		float num3 = 0.7f;
		int scytheWhipProjectile = ProjectileID.ScytheWhipProj;
		Main.instance.LoadProjectile(scytheWhipProjectile);
		Color value = new Color(255, 255, 255, 255);
		colors[0].A = 0;
		for (float i = 0f; i < 1f; i += 1f / amount) {
			float rotation = (float)Math.PI * 2f * i + num + Main.rand.NextFloatDirection() * 0.25f;
			float num7 = Main.rand.NextFloat() * 4f + 0.1f;
			Vector2 vector = Main.rand.NextVector2Circular(12f, 12f) * num3;
			Color.Lerp(Color.Lerp(colors[1], colors[0], Main.rand.NextFloat() * 0.5f), value, Main.rand.NextFloat() * 0.6f);
			Color colorTint = new Color(0, 0, 0, 255);
			int randomNumber = Main.rand.Next(4);
			if (randomNumber == 1)
				colorTint = Color.Lerp(new Color(106, 90, 205, 127), colors[1], 0.1f + 0.7f * Main.rand.NextFloat());
			if (randomNumber == 2)
				colorTint = Color.Lerp(new Color(106, 90, 205, 60), colors[1], 0.1f + 0.8f * Main.rand.NextFloat());
			RandomizedFrameParticle randomizedFrameParticle = ParticleOrchestraHelper.RandomizedFramePool.RequestParticle();
			randomizedFrameParticle.SetBasicInfo(TextureAssets.Projectile[scytheWhipProjectile], null, Vector2.Zero, vector);
			randomizedFrameParticle.SetTypeInfo(Main.projFrames[scytheWhipProjectile], 2, 24f);
			randomizedFrameParticle.Velocity = rotation.ToRotationVector2() * num7 * new Vector2(1f, 0.5f);
			randomizedFrameParticle.ColorTint = colorTint;
			randomizedFrameParticle.LocalPosition = settings.PositionInWorld + vector;
			randomizedFrameParticle.Rotation = rotation;
			randomizedFrameParticle.Scale = Vector2.One;
			randomizedFrameParticle.FadeInNormalizedTime = 0.01f;
			randomizedFrameParticle.FadeOutNormalizedTime = 0.5f;
			randomizedFrameParticle.ScaleVelocity = new Vector2(0.05f);
			Main.ParticleSystem_World_OverPlayers.Add(randomizedFrameParticle);
		}
    }
}