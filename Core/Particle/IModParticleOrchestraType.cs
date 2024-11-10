using Terraria.GameContent.Drawing;

namespace BiomeExpansion.Core.Particle;

public interface IModParticleOrchestraType
{
    void Spawn(ParticleOrchestraSettings settings, Color[] colors, int dustID, float timeToLive);
}