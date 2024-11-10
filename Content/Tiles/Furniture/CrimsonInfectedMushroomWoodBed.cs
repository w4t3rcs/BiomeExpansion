using Terraria.GameContent.ObjectInteractions;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodBed : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodBed"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodBedHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBed(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodBed>());
    }

	public override void MouseOver(int i, int j) {
		TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodBed>());
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) {
		return TileInteractionHelper.RightClickOnBed(i, j);
	}
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}