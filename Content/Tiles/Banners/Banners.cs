using BiomeExpansion.Content.NPCs.Enemies;
using BiomeExpansion.Content.Tiles.Biome;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Banners;

public class Banners : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["Banners"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBanner(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = -1;
        AddMapEntry(Color.DarkCyan);
    }

    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        Tile tile = Main.tile[i, j];
        TileObjectData data = TileObjectData.GetTileData(tile);
        int topLeftX = i - tile.TileFrameX / 18 % data.Width;
        int topLeftY = j - tile.TileFrameY / 18 % data.Height;
        if (WorldGen.IsBelowANonHammeredPlatform(topLeftX, topLeftY))
            offsetY -= 8;
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (!closer) return;
        Player player = Main.LocalPlayer;
        if (player is null || !player.active || player.dead) return;
        int style = Main.tile[i, j].TileFrameX / 18;
        int npc = GetBannerNPC(style);
        if (npc != -1)
        {
            Main.SceneMetrics.NPCBannerBuff[npc] = true;
            Main.SceneMetrics.hasBanner = true;
        }
    }

    public static int GetBannerNPC(int style)
    {
        int npc = -1;
        switch (style)
        {
            case 0:
                npc = ModContent.NPCType<FearClot>();
                break;
            case 1:
                npc = ModContent.NPCType<CorruptionInfectedSlime>();
                break;
            case 2:
                npc = ModContent.NPCType<CrimsonInfectedSlime>();
                break;
            case 3:
                npc = ModContent.NPCType<TerrorGhost>();
                break;
            case 4:
                npc = ModContent.NPCType<CorruptionInfectedEye>();
                break;
            case 5:
                npc = ModContent.NPCType<CrimsonInfectedEye>();
                break;
            case 6:
                npc = ModContent.NPCType<CorruptionInfectedDiggerHead>();
                break;
            case 7:
                npc = ModContent.NPCType<CrimsonInfectedDiggerHead>();
                break;
        }

        return npc;
    }
}