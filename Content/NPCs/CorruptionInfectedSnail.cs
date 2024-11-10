using BiomeExpansion.Content.Biomes;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedSnail : ModNPC
    {
        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSnail"];

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
            AIType = NPCID.GlowingSnail;
            AnimationType = NPCID.GlowingSnail;
            NPC.aiStyle = NPCAIStyleID.Snail;
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
            // When an item sprite is made, uncomment the next line
            //NPC.catchItem = ModContent.ItemType<CorruptionInfectedFlyNPC>();
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange([
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
                new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedSnail")
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
