// using BiomeExpansion.Content.Items.Placeable.Furniture;
// using BiomeExpansion.Content.Tiles.Biome;
// using BiomeExpansion.Content.Tiles.Plants;
// using BiomeExpansion.Content.Tiles.Sands;
// using ReLogic.Content;
// using Terraria.GameContent;

// namespace BiomeExpansion.Content.Trees;

// public class GiantCrimsonInfectedMushroomSnow : ModTree
// {
//     public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/GiantCrimsonInfectedMushroomSnow");
//     public override Asset<Texture2D> GetBranchTextures() => ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/GiantCrimsonInfectedMushroomBranchesSnow");
//     public override Asset<Texture2D> GetTopTextures() => ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/GiantCrimsonInfectedMushroomTopsSnow");
//     public override int CreateDust() => DustID.Crimson;
//     public override bool CanDropAcorn() => false;
//     public override int DropWood() => ModContent.ItemType<CrimsonInfectedMushroomWood>();
//     public override TreePaintingSettings TreeShaderSettings => new()
//     {
//         UseSpecialGroups = true,
//         SpecialGroupMinimalHueValue = 11f / 72f,
//         SpecialGroupMaximumHueValue = 0.25f,
//         SpecialGroupMinimumSaturationValue = 0.88f,
//         SpecialGroupMaximumSaturationValue = 1f
//     };
    
//     public override void SetStaticDefaults() 
//     {
//         // GrowsOnTileId = [ModContent.TileType<CrimsonInfectedMushroomGrassSnow>()];
//     }

//     public override int SaplingGrowthType(ref int style)
//     {
//         style = 0;
//         return ModContent.TileType<CrimsonInfectedSmallMushroom>();
//     } 
    
//     public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
//     {
//         topTextureFrameWidth = 112;
//         topTextureFrameHeight = 94;
//     }
    
//     public override bool Shake(int x, int y, ref bool createLeaves)
//     {
//         return false;
//     }
// }