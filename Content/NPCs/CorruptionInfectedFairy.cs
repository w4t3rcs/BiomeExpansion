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
    public class CorruptionInfectedFairy : ModNPC
    {
        private const int ClonedNPCID = NPCID.FairyCritterBlue;

        public override string Texture => TextureHelper.DynamicNPCsTextures["CorruptionInfectedFairyNPC"];

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
            //Main.npcCatchable[NPC.type] = true;

            //NPCID.Sets.CountsAsCritter[NPC.type] = true;
            //NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[NPC.type] = true;

            // Change and uncomment the next line if the fairy should be immune to anything
            //NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.INSERT_DEBUFF_HERE] = true;
            base.SetStaticDefaults();
        }


        public override void SetDefaults()
        {
            NPC.CloneDefaults(ClonedNPCID);

            AIType = ClonedNPCID;
            AnimationType = ClonedNPCID;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.BiomeExpansion.Bestiary.CorruptionInfectedFairy")
            });
        }
    }
}
