using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CrimsonInfectedButterfly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedButterfly"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Butterfly);
            AIType = NPCID.Butterfly;
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        }

        public override void FindFrame(int frameHeight)
        {
            Vector2 direction = NPC.velocity;
            direction.Normalize();
            NPC.spriteDirection = NPC.direction = NPC.velocity.X > 0 ? 1 : -1;
            FrameHelper.AnimateNPC(NPC, frameHeight, 6, 4);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedButterfly")
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
