using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Trees;

public class CorruptionInfectedBigMushroom : ModTree
{
    private Asset<Texture2D> _texture;
    private Asset<Texture2D> _branchesTexture;
    private Asset<Texture2D> _topsTexture;
    public override Asset<Texture2D> GetTexture() => _texture;
    public override Asset<Texture2D> GetBranchTextures() => _branchesTexture;
    public override Asset<Texture2D> GetTopTextures() => _topsTexture;
    public override int CreateDust() => DustID.Corruption;
    public override bool CanDropAcorn() => false;
    public override int DropWood() => ModContent.ItemType<Items.Placeable.CorruptionInfectedSmallMushroom>();
    public override TreePaintingSettings TreeShaderSettings => new()
    {
        UseSpecialGroups = true,
        SpecialGroupMinimalHueValue = 11f / 72f,
        SpecialGroupMaximumHueValue = 0.25f,
        SpecialGroupMinimumSaturationValue = 0.88f,
        SpecialGroupMaximumSaturationValue = 1f
    };
    
    public override void SetStaticDefaults() 
    {
        GrowsOnTileId = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        _texture = ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/BigInfectedMushroom");
        _branchesTexture = ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/BigCorruptionInfectedMushroomBranches");
        _topsTexture = ModContent.Request<Texture2D>("BiomeExpansion/Assets/Trees/BigCorruptionInfectedMushroomTops");
    }

    public override int SaplingGrowthType(ref int style)
    {
        style = 0;
        return ModContent.TileType<CorruptionInfectedSmallMushroom>();
    } 
    
    public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
    {
    }
}