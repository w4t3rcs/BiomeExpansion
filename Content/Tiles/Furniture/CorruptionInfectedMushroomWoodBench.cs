using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodBench : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodBench"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodBenchHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.Set3X2Chair(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBench>());
    }
    
    public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
    {
		TileInteractionHelper.ModifyBenchSittingInfo(i, j, ref info);
    }

	public override void MouseOver(int i, int j) {
		TileInteractionHelper.MouseOverBench(i, j, ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBench>());
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
	}

	public override bool RightClick(int i, int j) {
		return TileInteractionHelper.RightClickSit(i, j);
	}
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}