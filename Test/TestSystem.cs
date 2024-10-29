using BiomeExpansion.Content.Tiles;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ModLoader;

namespace BiomeExpansion.Test;

public class TestSystem : ModSystem
{
    public static bool JustPressed(Keys key) {
        return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
    }

    public override void PostUpdateWorld() {
        if (JustPressed(Keys.K)) 
            PlaceDecoration((ushort)ModContent.TileType<CorruptionInfectedMushroomCaveBigMushroom>(), (int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 2, 3, 3); 
        else if (JustPressed(Keys.L)) 
            PlaceDecoration((ushort)ModContent.TileType<CorruptionInfectedMushroomCaveRock>(), (int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 3, 3, 2);
    }
    
    private static void PlaceDecoration(ushort decorationTile, int x, int y, int frameCount, int width, int height)
    {
        Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + width, y + height) * 16, 2, Color.YellowGreen, null);
        WorldGen.PlaceTile(x, y, decorationTile);
        if (frameCount != 0) FrameHelper.SetRandomXxXFrame(x, y, width, height, frameCount);
    }
}