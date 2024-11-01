using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Placeable.Furniture;

public class CorruptionInfectedMushroomWoodTorch : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedMushroomWoodTorch"];
    
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
        ItemID.Sets.Torches[Item.type] = true;
        ItemID.Sets.SingleUseInGamepad[Type] = true;
        ItemID.Sets.WaterTorches[Item.type] = true;
        ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.ShimmerTorch;
    }
    
    public override void SetDefaults()
    {
        Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.CorruptionInfectedMushroomWoodTorch>());
        Item.width = 14;
        Item.height = 16;
        Item.holdStyle = 1;
        Item.noWet = false;
        Item.flame = true;
        Item.value = 500;
    }

    public override void HoldItem(Player player)
    {
        if (Main.rand.NextBool(player.itemAnimation > 0 ? 20 : 40))
            Dust.NewDust(new Vector2(player.itemLocation.X + 10f * player.direction, player.itemLocation.Y - 26f * player.gravDir), 4, 4, DustID.BlueFlare);
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 0f, 0.6f, 1.0f);
    }

    public override void PostUpdate()
    {
        Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0f, 0.3f, 1.2f);
    }
}