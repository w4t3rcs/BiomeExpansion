using BiomeExpansion.Content.Items.Placeable.Furniture;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodDoorClosed : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodDoorClosed"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodDoorClosedHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetDoorClosed(this, ModContent.TileType<CorruptionInfectedMushroomWoodDoorOpen>());
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<CorruptionInfectedMushroomWoodDoor>());
    }
    
    public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

    public override void MouseOver(int i, int j)
    {
        TileInteractionHelper.MouseOver(ModContent.ItemType<CorruptionInfectedMushroomWoodDoor>());
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}