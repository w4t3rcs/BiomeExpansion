using System;
using System.Linq;

namespace BiomeExpansion.Core.Generation;

public class RectangleBiomePlacer : IBiomePlacer
{
    public void Place(BEBiome biome, ushort[] tiles)
    {
        if (tiles.Length == 0) return;
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateBiomeVertically(i, startY, endY, tiles[0], tiles[1], tiles[2], tiles[3]);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, tiles[0], tiles[1], tiles[2], tiles[3]);
    }

    public void PlaceOnlyWithMainTile(BEBiome biome, ushort mainTile)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateBiomeVertically(i, startY, endY, mainTile);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, mainTile);
    }
    
    private void GenerateBiomeVertically(int x, int startY, int endY, ushort dirt, ushort grass, ushort stone, ushort sand = 0) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            if (sand != 0) PlaceSand(x, y, sand);
            PlaceStone(x, y, stone);
        }
    }

    private void GenerateBiomeVertically(int x, int startY, int endY, ushort mainTile) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceMainTile(x, y, mainTile);
        }
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, ushort dirt, ushort grass, ushort stone, ushort sand = 0) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            if (sand != 0) PlaceSand(x, y, sand);
            PlaceStone(x, y, stone);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            if (sand != 0) PlaceSand(x, y, sand);
            PlaceStone(x, y, stone);
        }
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, ushort mainTile) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceMainTile(x, y, mainTile);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceMainTile(x, y, mainTile);
        }
    }
    
    private void PlaceDirt(int x, int y, ushort tileType)
    {
        if (!BiomeHelper.StoneTiles.Contains(Main.tile[x, y].TileType) && !BiomeHelper.SandTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private void PlaceGrass(int x, int y, ushort dirt, ushort grass)
    {
        WorldGen.SpreadGrass(x, y, dirt, grass);
    }

    private void PlaceSand(int x, int y, ushort tileType)
    {
        if (BiomeHelper.SandTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private void PlaceStone(int x, int y, ushort tileType)
    {
        if (BiomeHelper.StoneTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }

    private void PlaceMainTile(int x, int y, ushort tileType)
    {
        WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
}