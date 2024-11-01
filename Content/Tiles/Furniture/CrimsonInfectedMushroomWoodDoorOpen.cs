﻿using BiomeExpansion.Content.Items.Placeable.Furniture;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
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
        Player player = Main.LocalPlayer;
        player.noThrow = 2;
        player.cursorItemIconEnabled = true;
        player.cursorItemIconID = ModContent.ItemType<CrimsonInfectedMushroomWoodDoor>();
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}