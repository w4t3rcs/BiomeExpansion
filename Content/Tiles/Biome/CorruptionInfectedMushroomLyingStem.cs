﻿using BiomeExpansion.Content.NPCs;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Biome;

public class CorruptionInfectedMushroomLyingStem : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomLyingStem"];

    public override void SetStaticDefaults()
    {
        TileHelper.Set3X2BiomeSurfaceDecoration(Type);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 4;
    }

    public override void DropCritterChance(int i, int j, ref int wormChance, ref int grassHopperChance, ref int jungleGrubChance)
    {
        if (NPC.CountNPCS(NPCID.EnchantedNightcrawler) < 5 && Main.rand.NextBool(6))
        {
            int worm = NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16 + 10, j * 16, NPCID.EnchantedNightcrawler);
            Main.npc[worm].TargetClosest();
            Main.npc[worm].velocity.Y = Main.rand.NextFloat(-5f, -2.1f);
            Main.npc[worm].velocity.X = Main.rand.NextFloat(0f, 2.6f) * -Main.npc[worm].direction;
            Main.npc[worm].direction *= -1;
            Main.npc[worm].netUpdate = true;
        }

        if (NPC.CountNPCS(ModContent.NPCType<CorruptionInfectedCaterpillar>()) < 5 && Main.rand.NextBool(6))
        {
            int caterpillar = NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16 + 10, j * 16, ModContent.NPCType<CorruptionInfectedCaterpillar>());
            Main.npc[caterpillar].TargetClosest();
            Main.npc[caterpillar].velocity.Y = Main.rand.NextFloat(-5f, -2.1f);
            Main.npc[caterpillar].velocity.X = Main.rand.NextFloat(0f, 2.6f) * -Main.npc[caterpillar].direction;
            Main.npc[caterpillar].direction *= -1;
            Main.npc[caterpillar].netUpdate = true;
        }
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Purple;
        return true;
    }
}