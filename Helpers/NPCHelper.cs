using Terraria;

namespace BiomeExpansion.Helpers;

public static class NPCHelper
{
    public static void AdjustExpertMode(NPC npc)
    {
        if (!Main.expertMode) return;
        npc.damage = (int)(npc.damage * 1.25f);
        npc.knockBackResist = (int)(npc.knockBackResist * 1.35f);
    }

    public static void AdjustMasterMode(NPC npc)
    {
        if (!Main.masterMode) return;
        npc.lifeMax = (int)(npc.lifeMax * 1.45f);
        npc.damage = (int)(npc.damage * 1.65f);
        npc.knockBackResist = (int)(npc.knockBackResist * 1.65f);
    }

    public static void DoHitDust(NPC npc, int hitDirection, int dustType = 5, float xSpeedMultiplier = 1f, int hitDustCount = 5, int deathDustCount = 20)
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

    private static void CreateNPCDust(NPC npc, int hitDirection, int dustType, float xSpeedMultiplier)
    {
        Dust.NewDust(npc.position, npc.width, npc.height, dustType, hitDirection * xSpeedMultiplier, -1f);
    }
}