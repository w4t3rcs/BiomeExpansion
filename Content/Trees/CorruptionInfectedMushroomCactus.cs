using BiomeExpansion.Content.Items.Placeable.Furniture;
using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Plants;
using BiomeExpansion.Content.Tiles.Sands;
using ReLogic.Content;
using Terraria.GameContent;

namespace BiomeExpansion.Content.Trees;

public class CorruptionInfectedMushroomCactus : ModCactus
{
    public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/CorruptionInfectedMushroomCactus");
    public override Asset<Texture2D> GetFruitTexture() => null;
    
    public override void SetStaticDefaults() 
    {
        GrowsOnTileId = [ModContent.TileType<CorruptionInfectedMushroomSand>()];
    }
}