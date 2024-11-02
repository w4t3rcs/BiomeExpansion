using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Items.Others;

public class CorruptionInfectedGel : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["CorruptionInfectedGel"];
    
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Gel);
        Item.color = Color.White;
        Item.alpha = 15;
    }
}