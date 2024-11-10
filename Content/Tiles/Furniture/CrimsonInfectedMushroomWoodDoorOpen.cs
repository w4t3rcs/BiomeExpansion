using BiomeExpansion.Content.Items.Placeable.Furniture;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodDoorOpen : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodDoorOpen"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodDoorOpenHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetDoorOpen(this, ModContent.TileType<CrimsonInfectedMushroomWoodDoorClosed>());
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<CrimsonInfectedMushroomWoodDoor>());
    }
    
    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

    public override void MouseOver(int i, int j)
    {
        TileInteractionHelper.MouseOver(ModContent.ItemType<CrimsonInfectedMushroomWoodDoor>());
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}