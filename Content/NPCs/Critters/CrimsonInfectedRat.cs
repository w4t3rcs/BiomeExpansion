using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Critters
{
    public class CrimsonInfectedRat : ModNPC
    {
        private const int RatNPCType = NPCID.Rat;

        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedRat"];

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
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedRat")
            ]);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.InModBiome<CrimsonInfectedMushroomSurfaceBiome>())
            {
                return 0.2f;
            }

            return 0f;
        }
    }
}
