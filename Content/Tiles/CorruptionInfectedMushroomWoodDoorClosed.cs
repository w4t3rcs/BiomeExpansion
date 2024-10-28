﻿using BiomeExpansion.Content.Items.Placeable.Furniture;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomWoodDoorClosed : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomWoodDoorClosed");
    public override string HighlightTexture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodDoorClosedHighlight");

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
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<CorruptionInfectedMushroomWoodDoor>();
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}