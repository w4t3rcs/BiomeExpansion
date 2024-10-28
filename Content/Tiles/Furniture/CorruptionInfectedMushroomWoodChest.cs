using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodChest : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomWoodChest");
    public override string HighlightTexture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodChestHighlight");

    public override void SetStaticDefaults()
    {
        TileHelper.SetChest(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChest>());
    }

	public override void MouseOver(int i, int j) {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[i, j];
        string chestName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
        int left = i;
        int top = j;
        if (tile.TileFrameX % 36 != 0) left--;
        if (tile.TileFrameY != 0) top--;
        int chest = Chest.FindChest(left, top);
        player.cursorItemIconID = -1;
        if (chest < 0)
        {
            player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
        }
        else
        {
            player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : chestName;
            if (player.cursorItemIconText == chestName)
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChest>();
                player.cursorItemIconText = "";
            }
        }
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
	}

    public override void MouseOverFar(int i, int j)
    {
        MouseOver(i, j);
        Player player = Main.LocalPlayer;
        if (player.cursorItemIconText == "")
        {
            player.cursorItemIconEnabled = false;
            player.cursorItemIconID = 0;
        }
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) 
	{
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[i, j];
        Main.mouseRightRelease = false;
        int left = i;
        int top = j;
        if (tile.TileFrameX % 36 != 0) left--;
        if (tile.TileFrameY != 0) top--;
        if (player.sign >= 0)
        {
            SoundEngine.PlaySound(SoundID.MenuClose);
            player.sign = -1;
            Main.editSign = false;
            Main.npcChatText = "";
        }
        if (Main.editChest)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            Main.editChest = false;
            Main.npcChatText = "";
        }
        if (player.editedChestName)
        {
            NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1,
                NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
            player.editedChestName = false;
        }
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            if (left == player.chestX && top == player.chestY && player.chest >= 0)
            {
                player.chest = -1;
                Recipe.FindRecipes();
                SoundEngine.PlaySound(SoundID.MenuClose);
            }
            else
            {
                NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, (float)top, 0f, 0f, 0, 0, 0);
                Main.stackSplit = 600;
            }
        }
        else
        {
            int chest = Chest.FindChest(left, top);
            if (chest < 0) return true;
            Main.stackSplit = 600;
            if (chest == player.chest)
            {
                player.chest = -1;
                SoundEngine.PlaySound(SoundID.MenuClose);
            }
            else
            {
                player.chest = chest;
                Main.playerInventory = true;
                Main.recBigList = false;
                player.chestX = left;
                player.chestY = top;
                SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
            }
            Recipe.FindRecipes();
        }
        return true;
    }

	public override LocalizedText DefaultContainerName(int frameX, int frameY)
	{
		ModItem item = ItemLoader.GetItem(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChest>());
		return item.GetLocalization("DisplayName");
	}

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Chest.DestroyChest(i, j);
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}