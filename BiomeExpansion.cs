using BiomeExpansion.Helpers;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
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
				ShaderHelper.LoadNewShader("BiomeExpansion:CorruptionBloodMoonFilterShader", new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(83, 62, 125).UseOpacity(0.95f), EffectPriority.High));
				ShaderHelper.LoadNewShader("BiomeExpansion:CrimsonBloodMoonFilterShader", new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(171, 22, 22).UseOpacity(0.95f), EffectPriority.High));
			
				// Asset<Effect> crimsonEffect = Assets.Request<Effect>("Effects/CrimsonInfectedShader");
				// ShaderHelper.LoadNewShader("BiomeExpansion:CrimsonInfectedShader", new Filter(new ScreenShaderData(crimsonEffect, "BiomeExpansion:CrimsonInfectedShader").UseIntensity(1f).UseProgress(Main.GameUpdateCount / 60f), EffectPriority.High));
			}
		}
	}
}
