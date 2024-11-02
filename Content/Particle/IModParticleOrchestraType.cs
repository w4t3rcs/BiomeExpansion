using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;

namespace BiomeExpansion.Content.Particle;

public interface IModParticleOrchestraType
{
    void Spawn(ParticleOrchestraSettings settings, Color[] colors, float timeToLive);
}