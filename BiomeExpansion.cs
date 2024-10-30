using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Content.Skies;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class BiomeExpansion : Mod
	{
		public override void Load()
		{
			TextureHelper.LoadDynamicTextures();
			if (Main.netMode != NetmodeID.Server)
			{
				SkyManager.Instance["BiomeExpansion:CorruptionInfectedMushroomSurfaceBiome"] = new CorruptionSky();
				SkyManager.Instance["BiomeExpansion:CrimsonInfectedMushroomSurfaceBiome"] = new CrimsonSky();
			}
		}
	}

	public class BiomeExpansionPlayer : ModPlayer
	{
		public bool isSporeInfected = false;

		public override void ResetEffects()
		{
			isSporeInfected = false;
		}

		public override void UpdateBadLifeRegen()
		{
			if (isSporeInfected)
			{
				Player.lifeRegenTime = 0;
				if (Main.rand.NextBool(2))
				{
					Player.lifeRegen -= 2;
				}
			}
		}

		public override void PostUpdate()
		{
			if (Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
			{
				Player.AddBuff(ModContent.BuffType<CorruptionSporeInfectionDebuff>(), 60);
			}
			else if (Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
			{
				Player.AddBuff(ModContent.BuffType<CrimsonSporeInfectionDebuff>(), 60);
			}
		}
	}
}
