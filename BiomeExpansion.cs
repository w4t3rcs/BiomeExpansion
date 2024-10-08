using BiomeExpansion.Helpers;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace BiomeExpansion
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class BiomeExpansion : Mod
	{
		public override void Load()
		{
			ShaderHelper.LoadNewShader("BiomeExpansion:CorruptionInfectedMushroomShader", new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(83, 62, 125).UseOpacity(0.95f), EffectPriority.High));
			ShaderHelper.LoadNewShader("BiomeExpansion:CrimsonInfectedMushroomShader", new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(171, 22, 22).UseOpacity(0.95f), EffectPriority.High));
		}
	}
}
