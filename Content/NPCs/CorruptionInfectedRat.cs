using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedRat : ModNPC
    {
        private const int RatNPCType = NPCID.Rat;

        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedRat"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(RatNPCType);
            AnimationType = RatNPCType;
            AIType = RatNPCType;
            NPC.aiStyle = NPCAIStyleID.Passive;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedRat")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CorruptionInfectedMushroomSurfaceBiome>())
            {
                return 0.2f;
            }

            return 0f;
        }
    }
}
