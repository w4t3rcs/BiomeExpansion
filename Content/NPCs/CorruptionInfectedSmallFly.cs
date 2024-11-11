using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedSmallFly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSmallFly"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
            // Change and uncomment the next line if the fly should be immune to anything
            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.INSERT_DEBUFF_HERE] = true;
        }

        public override void FindFrame(int frameHeight)
        {
            FrameHelper.AnimateNPC(NPC, frameHeight, 6, 4);
        }


        public override void SetDefaults()
        {
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            NPC.CloneDefaults(NPCID.Butterfly);
            AIType = NPCID.Butterfly;
            AnimationType = NPC.type;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
            // When an item sprite is made, uncomment the next line
            //NPC.catchItem = ModContent.ItemType<CorruptionInfectedFlyNPC>();
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedSmallFly")
            ]);
        }

        public override void AI()
        {
            if (NPC.velocity.X > 0)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
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