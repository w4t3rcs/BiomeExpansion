using System.IO;
using System.Numerics;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Content.Buffs;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.NPCs
{
    public class CorruptionInfectedSnail : ModNPC
    {
        private const int ClonedNPCID = NPCID.Snail;

        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedSnailNPC"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
            Main.npcCatchable[NPC.type] = true;

            NPCID.Sets.CountsAsCritter[NPC.type] = true;
            NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;

            // Change and uncomment the next line if the snail should be immune to anything
            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.INSERT_DEBUFF_HERE] = true;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedSnail")
            });
        }

        public override void SetDefaults()
        {
            //NPC.width = 16;
            //NPC.height = 18;
            //NPC.defense = 0;
            //NPC.damage = 0;
            //NPC.lifeMax = 5;
            //NPC.knockBackResist = 0f;
            //NPC.HitSound = SoundID.NPCHit1;
            //NPC.DeathSound = SoundID.NPCDeath1; // Either NPCDeath1 or NPCDeath 12 sounds like it could fit

            NPC.aiStyle = NPCAIStyleID.Butterfly;
            // Set NPC.catchItem here
            SpawnModBiomes = [ModContent.GetInstance<CorruptionInfectedMushroomSurfaceBiome>().Type];
            NPC.CloneDefaults(ClonedNPCID);

            AIType = ClonedNPCID;
            AnimationType = ClonedNPCID;

            // When an item sprite is made, uncomment the next line
            //NPC.catchItem = ModContent.ItemType<CorruptionInfectedFlyNPC>();
        }


    }
}
