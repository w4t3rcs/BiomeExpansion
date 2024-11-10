using System;
using System.Linq;

namespace BiomeExpansion.Core.Generation;

public class RectangleBiomePlacer : IBiomePlacer
{
    public void Place(BEBiome biome, ushort[] tiles, ushort wall)
    {
        if (tiles.Length == 0) return;
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateBiomeVertically(i, startY, endY, tiles[0], tiles[1], tiles[2], wall);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, tiles[0], tiles[1], tiles[2], wall);
    }

    public void PlaceOnlyWithMainTile(BEBiome biome, ushort mainTile, ushort wall)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int i = leftX; i < rightX; i++)
            GenerateBiomeVertically(i, startY, endY, mainTile, wall);
        for (int i = startY; i < endY; i++)
            GenerateBiomeTransition(i, leftX, rightX, mainTile, wall);
    }
    
    private void GenerateBiomeVertically(int x, int startY, int endY, ushort dirt, ushort grass, ushort stone, ushort wall) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            PlaceStone(x, y, stone);
            PlaceWall(x, y, wall);
        }
    }

    private void GenerateBiomeVertically(int x, int startY, int endY, ushort mainTile, ushort wall) 
    {
        for (int y = startY; y < endY + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); y++)
        {
            PlaceMainTile(x, y, mainTile);
            PlaceWall(x, y, wall);
        }
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, ushort dirt, ushort grass, ushort stone, ushort wall) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            PlaceStone(x, y, stone);
            PlaceWall(x, y, wall);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceDirt(x, y, dirt);
            PlaceGrass(x, y, dirt, grass);
            PlaceStone(x, y, stone);
            PlaceWall(x, y, wall);
        }
    }

    private void GenerateBiomeTransition(int y, int leftX, int rightX, ushort mainTile, ushort wall) 
    {
        for (int x = leftX - Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x < leftX; x++)
        {
            PlaceMainTile(x, y, mainTile);
            PlaceWall(x, y, wall);
        }

        for (int x = rightX ; x < rightX + Main.rand.Next(BiomeHelper.MaximumBiomeTransitionLength); x++)
        {
            PlaceMainTile(x, y, mainTile);
            PlaceWall(x, y, wall);
        }
    }
    
    private void PlaceDirt(int x, int y, ushort tileType)
    {
        if (!BiomeHelper.StoneTiles.Contains(Main.tile[x, y].TileType))
            WorldGen.ReplaceTile(x, y, tileType, Main.tile[x, y].TileFrameX);
    }
    
    private void PlaceGrass(int x, int y, ushort dirt, ushort grass)
    {
        WorldGen.SpreadGrass(x, y, dirt, grass);
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
    
    private void PlaceWall(int x, int y, ushort wall)
    {
        WorldGen.ReplaceWall(x, y, wall);
    }
}