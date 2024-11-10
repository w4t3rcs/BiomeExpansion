using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Stones;

public class CrimsoomBar : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsoomBar"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBar(Type);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.CrimsoomBar>());
    }
}