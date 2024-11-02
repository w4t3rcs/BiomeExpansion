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
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodChest"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodChestHighlight"];

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
        TileInteractionHelper.MouseOverChest(i, j, ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChest>());
	}

    public override void MouseOverFar(int i, int j)
    {
        TileInteractionHelper.MouseOverChestFar(i, j, ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChest>());
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