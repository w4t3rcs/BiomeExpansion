using System.Globalization;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class InfectedMushroomWoodClock : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodClock");
    public override string HighlightTexture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodClockHighlight");

    public override void SetStaticDefaults()
    {
        TileHelper.SetClock(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodClock>());
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (closer) Main.SceneMetrics.HasClock = true;
    }
    
	public override void MouseOver(int i, int j) {
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodClock>();
	}
    
    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) 
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
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}