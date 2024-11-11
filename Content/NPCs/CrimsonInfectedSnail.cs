using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CrimsonInfectedSnail : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CrimsonInfectedSnail"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;
            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;
            // Change and uncomment the next line if the snail should be immune to anything
            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.INSERT_DEBUFF_HERE] = true;
        }


        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.GlowingSnail);
            AIType = NPCID.Snail;
            AnimationType = NPCID.Snail;
            NPC.aiStyle = NPCAIStyleID.Snail;
            SpawnModBiomes = [ModContent.GetInstance<CrimsonInfectedMushroomSurfaceBiome>().Type];
            // When an item sprite is made, uncomment the next line
            //NPC.catchItem = ModContent.ItemType<CrimsonInfectedFlyNPC>();
        }

        public override void AI()
        {
            Lighting.AddLight(NPC.Center, 0.4f, 0.0f, 0.4f);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CrimsonInfectedSnail")
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
