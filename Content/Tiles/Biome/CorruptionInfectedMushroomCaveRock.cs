using BiomeExpansion.Content.NPCs.Critters;
using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Generation;
using Terraria.DataStructures;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Biome;

public class CorruptionInfectedMushroomCaveRock : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveRock"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 3, 2, true, 3);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomStone>(), ModContent.TileType<CorruptionInfectedMushroomOldStone>()];
        this.AddGenerationTileData(TileObjectData.newTile);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }

    public override void DropCritterChance(int i, int j, ref int wormChance, ref int grassHopperChance, ref int jungleGrubChance)
    {
        if (NPC.CountNPCS(ModContent.NPCType<CorruptionInfectedGrasshopper>()) < 5 && Main.rand.NextBool(10))
        {
            int grasshopper = NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16 + 10, j * 16, ModContent.NPCType<CorruptionInfectedGrasshopper>());
            Main.npc[grasshopper].TargetClosest();
            Main.npc[grasshopper].velocity.Y = Main.rand.NextFloat(-5f, -2.1f);
            Main.npc[grasshopper].velocity.X = Main.rand.NextFloat(0f, 2.6f) * -Main.npc[grasshopper].direction;
            Main.npc[grasshopper].direction *= -1;
            Main.npc[grasshopper].netUpdate = true;
        }
        if (NPC.CountNPCS(ModContent.NPCType<CorruptionInfectedCaterpillar>()) < 5 && Main.rand.NextBool(10))
        {
            int caterpillar = NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16 + 10, j * 16, ModContent.NPCType<CorruptionInfectedCaterpillar>());
            Main.npc[caterpillar].TargetClosest();
            Main.npc[caterpillar].velocity.Y = Main.rand.NextFloat(-5f, -2.1f);
            Main.npc[caterpillar].velocity.X = Main.rand.NextFloat(0f, 2.6f) * -Main.npc[caterpillar].direction;
            Main.npc[caterpillar].direction *= -1;
            Main.npc[caterpillar].netUpdate = true;
        }
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}