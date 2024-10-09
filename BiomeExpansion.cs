using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class BiomeExpansion : Mod
	{
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				// Asset<Effect> crimsonEffect = Assets.Request<Effect>("Assets/Effects/CrimsonInfectedShader");
				// ShaderHelper.LoadNewShader("BiomeExpansion:CrimsonInfectedShader", new Filter(new ScreenShaderData(crimsonEffect, "BiomeExpansion:CrimsonInfectedShader").UseIntensity(1f).UseProgress(Main.GameUpdateCount / 60f), EffectPriority.High));
			}
		}
	}
}
