using Terraria.GameContent.ObjectInteractions;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class InfectedMushroomWoodClock : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodClock"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodClockHighlight"];

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
        TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodClock>());
	}
    
    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) 
	{
        return TileInteractionHelper.RightClickOnClock(i, j);
	}
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}