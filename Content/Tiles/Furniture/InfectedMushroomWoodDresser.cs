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
    public override string Texture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodDresser"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodDresserHighlight"];

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
        TileInteractionHelper.MouseOverDresser(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>());
	}

    public override void MouseOverFar(int i, int j)
    {
        TileInteractionHelper.MouseOverDresserFar(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodDresser>());
    }

    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) 
	{
        return TileInteractionHelper.RightClickOnDresser(i, j);
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