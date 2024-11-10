using Terraria.DataStructures;
using Terraria.GameContent;

namespace BiomeExpansion.Content.Items.Others;

public class FearPiece : ModItem
{
    public override string Texture => TextureHelper.DynamicItemsTextures["FearPiece"];
    
    public override void SetStaticDefaults()
    {
        Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 7));
        ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        ItemID.Sets.ItemNoGravity[Item.type] = true;  
        Item.ResearchUnlockCount = 25;
    }

    public override void SetDefaults()
    {
        Item.width = 42;
        Item.height = 60;
        Item.maxStack = Item.CommonMaxStack;
        Item.value = 1000;
        Item.rare = ItemRarityID.LightRed;
    }

    public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor,
        Vector2 origin, float scale)
    {
        const float newScale = 0.9f;
        position += new Vector2(1f, -7) * newScale;
        spriteBatch.Draw(TextureAssets.Item[Type].Value, position, frame, drawColor, 0f, origin, newScale, SpriteEffects.None, 0);
        return false;
    }

    public override void PostUpdate() {
        Lighting.AddLight(Item.Center, Color.Red.ToVector3() * 0.75f * Main.essScale);
    }
}