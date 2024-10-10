using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedSmallMushroom : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedSmallMushroom");

    public override void SetStaticDefaults()
    {
        TileHelper.SetFramePlant(Type, 5, 20);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CorruptionInfectedSmallMushroom>(), 0, 2, 3, 4);
    }
}