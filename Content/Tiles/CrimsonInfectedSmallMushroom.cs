using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedSmallMushroom : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetFramePlant(Type, 5, 20);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CrimsonInfectedSmallMushroom>(), 0, 2, 3, 4);
    }
}