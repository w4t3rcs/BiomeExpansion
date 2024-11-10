using Terraria.GameContent.ObjectInteractions;
using Terraria.Localization;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodChest : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodChest"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodChestHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetChest(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodChest>());
    }

	public override void MouseOver(int i, int j) {
        TileInteractionHelper.MouseOverChest(i, j, ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodChest>());
	}

    public override void MouseOverFar(int i, int j)
    {
        TileInteractionHelper.MouseOverChestFar(i, j, ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodChest>());
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) 
	{
        return TileInteractionHelper.RightClickOnChest(i, j);
    }

	public override LocalizedText DefaultContainerName(int frameX, int frameY)
	{
		ModItem item = ItemLoader.GetItem(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodChest>());
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