using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Enemies
{
    public class CorruptionInfectedCrab : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedCrab"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Crab);
            AIType = NPCID.Crab;
            NPC.aiStyle = NPCAIStyleID.Fighter;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
            NPCHelper.AdjustExpertMode(NPC);
            NPCHelper.AdjustMasterMode(NPC);
        }

        public override void FindFrame(int frameHeight)
        {
            Vector2 direction = NPC.velocity;
            direction.Normalize();
            NPC.spriteDirection = NPC.direction = NPC.velocity.X > 0 ? 1 : -1;
            FrameHelper.AnimateNPC(NPC, frameHeight, 6, 5);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedCrab")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
            {
                return 0.1f;
            }

            return 0f;
        }
    }
}
