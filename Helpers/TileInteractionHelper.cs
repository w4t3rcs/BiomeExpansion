using System.Globalization;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Localization;

namespace BiomeExpansion.Helpers;

public static class TileInteractionHelper
{
    public static void MouseOver(int itemId)
    {
        Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = itemId;
    }

    public static void MouseOverDresserFar(int itemId)
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
                player.cursorItemIconID = itemId;
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

    public static void MouseOverDresser(int itemId)
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
                player.cursorItemIconID = itemId;
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

    public static void MouseOverChestFar(int x, int y, int itemId)
    {
        MouseOverChest(x, y, itemId);
        Player player = Main.LocalPlayer;
        if (player.cursorItemIconText == "")
        {
            player.cursorItemIconEnabled = false;
            player.cursorItemIconID = 0;
        }
    }

    public static void MouseOverChest(int x, int y, int itemId)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[x, y];
        string chestName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
        int left = x;
        int top = y;
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
                player.cursorItemIconID = itemId;
                player.cursorItemIconText = "";
            }
        }
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
    }

    public static void MouseOverChair(int x, int y, int itemId)
    {
        Player player = Main.LocalPlayer;
		if (!player.IsWithinSnappngRangeToTile(x, y, PlayerSittingHelper.ChairSittingMaxDistance)) return;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = itemId;
		bool frameCheck = Main.tile[x, y].TileFrameX <= 35;
		if (frameCheck) player.cursorItemIconReversed = true;
    }

    public static void MouseOverBench(int x, int y, int itemId)
    {
        Player player = Main.LocalPlayer;
		if (!player.IsWithinSnappngRangeToTile(x, y, PlayerSittingHelper.ChairSittingMaxDistance)) return;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = itemId;
    }

    public static void ModifyChairSittingInfo(int i, int j, ref TileRestingInfo info)
    {
        const int nextStyleHeight = 40;
        info.DirectionOffset = 0;
        info.VisualOffset = new Vector2(-8f, 0f);
        Tile tile = Framing.GetTileSafely(i, j);
        bool frameCheck = tile.TileFrameX >= 35;
        info.TargetDirection = -1;
        if (frameCheck) info.TargetDirection = 1;
        int xPos = tile.TileFrameX / 18;
        if (xPos == 1) i--;
        if (xPos == 2) i++;
        info.AnchorTilePosition.X = i;
        info.AnchorTilePosition.Y = j;
        if (tile.TileFrameY % nextStyleHeight == 0) info.AnchorTilePosition.Y++;
    }

    public static void ModifyBenchSittingInfo(int i, int j, ref TileRestingInfo info)
    {
        const int nextStyleHeight = 40;
        Tile tile = Framing.GetTileSafely(i, j);
        Player player = Main.LocalPlayer;
        info.DirectionOffset = 0;
        float offset = 0f;
        if (tile.TileFrameX < 17 && player.direction == 1) offset = 8f;
        if (tile.TileFrameX < 17 && player.direction == -1) offset = -8f;
        if (tile.TileFrameX > 34 && player.direction == 1) offset = -8f;
        if (tile.TileFrameX > 34 && player.direction == -1) offset = 8f;
        info.VisualOffset = new Vector2(offset, 0f);
        info.TargetDirection = player.direction;
        info.AnchorTilePosition.X = i;
        info.AnchorTilePosition.Y = j;
        if (tile.TileFrameY % nextStyleHeight == 0) info.AnchorTilePosition.Y++;
    }

    public static bool RightClickOnDresser(int x, int y)
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

    public static bool RightClickOnClock(int x, int y)
    {
        string text = "AM";
        double time = Main.time;
        if (!Main.dayTime) time += 54000D;
        time /= 3600D;
        time -= 19.5;
        if (time < 0D) time += 24D;
        if (time >= 12D) text = "PM";
        int intTime = (int)time;
        double deltaTime = time - intTime;
        deltaTime = (int)(deltaTime * 60D);
        string minuteText = deltaTime.ToString(CultureInfo.InvariantCulture);
        if (deltaTime < 10D) minuteText = "0" + minuteText;
        if (intTime > 12) intTime -= 12;
        if (intTime == 0) intTime = 12;
        var newText = $"Time: {intTime}:{minuteText} {text}";
        Main.NewText(newText, 255, 240, 20);
        return true;
    }

    public static bool RightClickDestroy(int x, int y)
    {
        Tile tile = Main.tile[x, y];
        if (tile != null && tile.HasTile)
        {
            WorldGen.KillTile(x, y);
            if (!tile.HasTile && Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, x, y);
            }
        }
        
        return true;
    }

    public static bool RightClickOnChest(int x, int y)
    {
        Player player = Main.LocalPlayer;
        Tile tile = Main.tile[x, y];
        Main.mouseRightRelease = false;
        int left = x;
        int top = y;
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

    public static bool RightClickMechanic(int x, int y)
    {
        SoundEngine.PlaySound(SoundID.Mech, new Vector2(x * 16, y * 16));
		ToggleTile(x, y);
		return true;
    }

    public static bool RightClickSit(int x, int y)
    {
        Player player = Main.LocalPlayer;
		if (player.IsWithinSnappngRangeToTile(x, y, PlayerSittingHelper.ChairSittingMaxDistance))
		{
			player.GamepadEnableGrappleCooldown();
			player.sitting.SitDown(player, x, y);
		}

		return true;
    }

    public static bool RightClickOnBed(int x, int y)
    {
        Player player = Main.LocalPlayer;
		Tile tile = Main.tile[x, y];
		int spawnX = x - tile.TileFrameX / 18 + (tile.TileFrameX >= 72 ? 5 : 2);
		int spawnY = y + 2;
		if (tile.TileFrameY % 38 != 0) spawnY--;
		if (!Player.IsHoveringOverABottomSideOfABed(x, y))
		{
			if (!player.IsWithinSnappngRangeToTile(x, y, PlayerSleepingHelper.BedSleepingMaxDistance)) return true;
			player.GamepadEnableGrappleCooldown();
			player.sleeping.StartSleeping(player, x, y);
		}
		else
		{
			player.FindSpawn();
			if (player.SpawnX == spawnX && player.SpawnY == spawnY)
			{
				player.RemoveSpawn();
				Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
			}
			else if (Player.CheckSpawn(spawnX, spawnY))
			{
				player.ChangeSpawn(spawnX, spawnY);
				Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
			}
		}

		return true;
    }

    public static void ToggleTile(int i, int j) {
		Tile tile = Main.tile[i, j];
		int topX = i - tile.TileFrameX % 54 / 18;
		int topY = j - tile.TileFrameY % 36 / 18;
		short frameAdjustment = (short)(tile.TileFrameY >= 36 ? -36 : 36);
		for (int x = topX; x < topX + 3; x++) {
			for (int y = topY; y < topY + 2; y++) {
				Main.tile[x, y].TileFrameY += frameAdjustment;
				
				if (Wiring.running) { 
					Wiring.SkipWire(x, y);
				}
			}
		}

		if (Main.netMode != NetmodeID.SinglePlayer) { 
			NetMessage.SendTileSquare(-1, topX, topY, 3, 2);
		}
	}
}