using BiomeExpansion.Common.Dtos;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class InfectedSmallMushroom : SmallMushroomTile
{
    public override string Texture => "BiomeExpansion/Assets/Tiles/InfectedSmallMushroom";
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        Main.tileFrameImportant[Type] = true;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 0);
        TileObjectData.newTile.RandomStyleRange = 5;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.addTile(Type);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.InfectedSmallMushroom>());
    }
}