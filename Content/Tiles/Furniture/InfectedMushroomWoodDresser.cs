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

public class InfectedMushroomWoodDresser : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodDresser");
    public override string HighlightTexture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodDresserHighlight");

    public override void SetStaticDefaults()
    {
        TileHelper.SetDresser(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>());
    }

	public override void MouseOver(int i, int j)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
        string chestName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
        int left = Player.tileTargetX;
        int top = Player.tileTargetY;
        left -= tile.TileFrameX % 54 / 18;
        if (tile.TileFrameY % 36 != 0)
        {
            top--;
        }
        int chestIndex = Chest.FindChest(left, top);
        player.cursorItemIconID = -1;
        if (chestIndex < 0)
        {
            player.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
        }
        else
        {
            if (Main.chest[chestIndex].name != "")
            {
                player.cursorItemIconText = Main.chest[chestIndex].name;
            }
            else
            {
                player.cursorItemIconText = chestName;
            }
            if (player.cursorItemIconText == chestName)
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>();
                player.cursorItemIconText = "";
            }
        }
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY > 0)
        {
            player.cursorItemIconID = ItemID.FamiliarShirt;
        }
	}

    public override void MouseOverFar(int i, int j)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
        string chestName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
        int left = Player.tileTargetX;
        int top = Player.tileTargetY;
        left -= tile.TileFrameX % 54 / 18;
        if (tile.TileFrameY % 36 != 0)
        {
            top--;
        }
        int chestIndex = Chest.FindChest(left, top);
        player.cursorItemIconID = -1;
        if (chestIndex < 0)
        {
            player.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
        }
        else
        {
            if (Main.chest[chestIndex].name != "")
            {
                player.cursorItemIconText = Main.chest[chestIndex].name;
            }
            else
            {
                player.cursorItemIconText = chestName;
            }
            if (player.cursorItemIconText == chestName)
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>();
                player.cursorItemIconText = "";
            }
        }
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
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
        if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY == 0)
        {
            Main.CancelClothesWindow(true);
            int left = Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameX / 18;
            left %= 3;
            left = Player.tileTargetX - left;
            int top = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY / 18);
            if (player.sign > -1)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = string.Empty;
            }
            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }
            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
                player.editedChestName = false;
            }
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                if (left == player.chestX && top == player.chestY && player.chest != -1)
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
                return true;
            }
            else
            {
                player.piggyBankProjTracker.Clear();
                player.voidLensChest.Clear();
                int dresserChestID = Chest.FindChest(left, top);
                if (dresserChestID != -1)
                {
                    Main.stackSplit = 600;
                    if (dresserChestID == player.chest)
                    {
                        player.chest = -1;
                        Recipe.FindRecipes();
                        SoundEngine.PlaySound(SoundID.MenuClose);
                    }
                    else if (dresserChestID != player.chest && player.chest == -1)
                    {
                        player.chest = dresserChestID;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        SoundEngine.PlaySound(SoundID.MenuOpen);
                        player.chestX = left;
                        player.chestY = top;
                    }
                    else
                    {
                        player.chest = dresserChestID;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        SoundEngine.PlaySound(SoundID.MenuTick);
                        player.chestX = left;
                        player.chestY = top;
                    }
                    Recipe.FindRecipes();
                    return true;
                }
            }
        }
        else
        {
            Main.playerInventory = false;
            player.chest = -1;
            Recipe.FindRecipes();
            Main.interactedDresserTopLeftX = Player.tileTargetX;
            Main.interactedDresserTopLeftY = Player.tileTargetY;
            Main.OpenClothesWindow(); 
            return true;
        }
        return false;
    }

	public override LocalizedText DefaultContainerName(int frameX, int frameY)
	{
		ModItem item = ItemLoader.GetItem(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>());
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