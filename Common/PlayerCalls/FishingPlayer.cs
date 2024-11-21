using BiomeExpansion.Content.Biomes;
using Terraria.DataStructures;

namespace BiomeExpansion.Common.PlayerCalls;

public class FishingPlayer : ModPlayer
{
	public override void ModifyFishingAttempt(ref FishingAttempt attempt) {
		if (!attempt.crate) {
			if (Main.rand.NextBool(10)) {
				attempt.crate = true;
			}
		}
	}

	public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
		bool inWater = !attempt.inLava && !attempt.inHoney;
		bool inCorruptionInfectedMushroomBiome = Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>();
		bool inCrimsonInfectedMushroomBiome = Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>();
        if (npcSpawn > 0) return;
        if (itemDrop == ItemID.OldShoe || itemDrop == ItemID.FishingSeaweed || itemDrop == ItemID.TinCan) return;

		if (inWater && (inCorruptionInfectedMushroomBiome || inCrimsonInfectedMushroomBiome)) {
			if (attempt.crate && attempt.uncommon) {
				itemDrop = inCorruptionInfectedMushroomBiome 
                    ? ModContent.ItemType<Content.Items.Placeable.Crates.CorruptionInfectedMushroomCrate>() 
                    : ModContent.ItemType<Content.Items.Placeable.Crates.CrimsonInfectedMushroomCrate>();
				return;
			}

            if (attempt.common)
            {
                itemDrop = inCorruptionInfectedMushroomBiome 
                    ? ModContent.ItemType<Content.Items.Fishes.CorruptionInfectedMushroomFish>() 
                    : ModContent.ItemType<Content.Items.Fishes.CrimsonInfectedMushroomFish>();
				return;
            }
		}
	}
}