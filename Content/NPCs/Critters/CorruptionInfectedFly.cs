using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Critters
{
    public class CorruptionInfectedFly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedFly"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
        }

        public override void FindFrame(int frameHeight)
        {
            FrameHelper.AnimateNPCWithDirection(NPC, frameHeight, 6);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.Butterfly);
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            AIType = NPCID.Butterfly;
            AnimationType = NPC.type;
            NPC.catchItem = ModContent.ItemType<Items.NPCs.Critters.CorruptionInfectedFly>();
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedFly")
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