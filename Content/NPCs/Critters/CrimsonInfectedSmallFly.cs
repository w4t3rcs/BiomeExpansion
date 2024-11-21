using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs.Critters
{
    public class CrimsonInfectedSmallFly : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedSmallFly"];

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
            NPC.aiStyle = NPCAIStyleID.Butterfly;
            NPC.CloneDefaults(NPCID.Butterfly);
            AIType = NPCID.Butterfly;
            AnimationType = NPC.type;
            NPC.catchItem = ModContent.ItemType<Items.NPCs.Critters.CrimsonInfectedFly>();
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
        }
        
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedSmallFly")
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
