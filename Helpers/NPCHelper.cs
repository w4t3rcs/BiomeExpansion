namespace BiomeExpansion.Helpers;

public static class NPCHelper
{
    /// <summary>
    /// Adjust the <see cref="NPC"/> to have increased stats for Expert Mode.
    /// </summary>
    /// <param name="npc">The <see cref="NPC"/> to adjust.</param>
    /// <param name="isKnockbackIncreased">
    /// Whether to increase the NPC's knockback resistance.
    /// If <see langword="true"/>, the NPC's knockback resistance will be increased.
    /// </param>
    public static void AdjustExpertMode(NPC npc, bool isKnockbackIncreased = true)
    {
        if (!Main.expertMode) return;
        npc.lifeMax = (int)(npc.lifeMax * 1.75f);
        npc.damage = (int)(npc.damage * 1.75f);
        if (isKnockbackIncreased) npc.knockBackResist = (int)(npc.knockBackResist + 0.1f);
    }

    /// <summary>
    /// Adjust the <see cref="NPC"/> to have increased stats for Master Mode.
    /// </summary>
    /// <param name="npc">The <see cref="NPC"/> to adjust.</param>
    /// <param name="isKnockbackIncreased">
    /// Whether to increase the NPC's knockback resistance.
    /// If <see langword="true"/>, the NPC's knockback resistance will be increased.
    /// </param>
    public static void AdjustMasterMode(NPC npc, bool isKnockbackIncreased = true)
    {
        if (!Main.masterMode) return;
        npc.lifeMax = (int)(npc.lifeMax * 2.5f);
        npc.damage = (int)(npc.damage * 2.5f);
        if (isKnockbackIncreased) npc.knockBackResist = (int)(npc.knockBackResist + 0.2f);
    }
    
    /// <summary>
    /// Creates a certain amount of hit dust based on the given <paramref name="hitDirection"/>,
    /// <paramref name="dustType"/>, and <paramref name="xSpeedMultiplier"/>.
    /// If the NPC's life is 0 or less, creates a certain amount of death dust instead.
    /// </summary>
    /// <param name="npc">The <see cref="NPC"/> to create dust for.</param>
    /// <param name="hitDirection">The direction of the hit, in pixels.</param>
    /// <param name="dustType">The type of dust to create, defaulting to <see cref="DustID.Blood"/>.</param>
    /// <param name="xSpeedMultiplier">The multiplier for the x-speed of the created dust, defaulting to 1f.</param>
    /// <param name="hitDustCount">The amount of hit dust to create, defaulting to 5.</param>
    /// <param name="deathDustCount">The amount of death dust to create, defaulting to 20.</param>
    public static void DoHitDust(NPC npc, int hitDirection, int dustType = DustID.Blood, float xSpeedMultiplier = 1f, int hitDustCount = 5, int deathDustCount = 20)
    {
        for (int i = 0; i < hitDustCount; i++)
        {
            CreateNPCDust(npc, hitDirection, dustType, xSpeedMultiplier);
        }

        if (npc.life <= 0)
        {
            for (int i = 0; i < deathDustCount; i++)
            {
                CreateNPCDust(npc, hitDirection, dustType, xSpeedMultiplier);
            }
        }
    }

    /// <summary>
    /// Creates a single piece of dust for the given <paramref name="npc"/>,
    /// with the given <paramref name="hitDirection"/>, <paramref name="dustType"/>,
    /// and <paramref name="xSpeedMultiplier"/>.
    /// </summary>
    /// <param name="npc">The <see cref="NPC"/> to create dust for.</param>
    /// <param name="hitDirection">The direction of the hit, in pixels.</param>
    /// <param name="dustType">The type of dust to create, defaulting to <see cref="DustID.Blood"/>.</param>
    /// <param name="xSpeedMultiplier">The multiplier for the x-speed of the created dust, defaulting to 1f.</param>
    public static void CreateNPCDust(NPC npc, int hitDirection, int dustType, float xSpeedMultiplier)
    {
        Dust.NewDust(npc.position, npc.width, npc.height, dustType, hitDirection * xSpeedMultiplier, -1f);
    }

    public static void CreateGoreOnDeath(NPC npc, string textureName = "")
    {
        if (Main.netMode != NetmodeID.Server && npc.life <= 0) {
			int gore = ModContent.GetInstance<BiomeExpansion>().Find<ModGore>(textureName).Type;
			Gore.NewGoreDirect(npc.GetSource_Death(), npc.position, npc.velocity, gore, 1f);
		}
    }
}