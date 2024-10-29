using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Others;

public class CorruptionInfectedMushroomSeeds : ModItem
{
    public override string Texture => TextureHelper.GetDynamicItemTexture("CorruptionInfectedMushroomSeeds");
    
    public override void SetStaticDefaults()
    {
        ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.width = 12;
        Item.height = 12;
        Item.useTurn = true;
        Item.autoReuse = true;
        Item.consumable = true;
        Item.useTime = 10;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
    }
    
    public override bool? UseItem(Player player)
    {
        Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);
        if (tile.HasTile && tile.TileType == ModContent.TileType<InfectedMushroomDirt>() && player.IsInTileInteractionRange(Player.tileTargetX, Player.tileTargetY, TileReachCheckSettings.Simple))
        {
            Main.tile[Player.tileTargetX, Player.tileTargetY].TileType = (ushort)ModContent.TileType<CorruptionInfectedMushroomGrass>();
            SoundEngine.PlaySound(SoundID.Dig, player.Center);
            return true;
        }

        return false;
    }
}