using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Waters;
using Terraria.Audio;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomFountain : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomFountain"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomFountainHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetFountain(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Glass;
        AnimationFrameHeight = 72;
        AddMapEntry(Color.DarkCyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomFountain>());
    }

    public override void AnimateTile(ref int frame, ref int frameCounter)
    {
        frameCounter++;
        if (frameCounter >= 6)
        {
            frame = (frame + 1) % 6;
            frameCounter = 0;
        }
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (!Main.dedServ && Main.tile[i, j].TileFrameX >= 36)
            Main.SceneMetrics.ActiveFountainColor = ModContent.GetInstance<CorruptionInfectedMushroomWaterStyle>().Slot;
    }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool CreateDust(int i, int j, ref int type)
        {
            Dust.NewDust(new Vector2(i, j) * 16f, 16, 16, DustID.Stone, 0f, 0f, 1, new Color(119, 102, 255), 1f);
            Dust.NewDust(new Vector2(i, j) * 16f, 16, 16, DustID.Water, 0f, 0f, 1, new Color(255, 255, 255), 1f);
            return false;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void HitWire(int i, int j)
        {
            FrameHelper.LightHitWire(Type, i, j, 2, 4);
        }

        public override bool RightClick(int i, int j)
        {
            FrameHelper.LightHitWire(Type, i, j, 2, 4);
            SoundEngine.PlaySound(SoundID.Mech, new Vector2(i * 16, j * 16));
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomFountain>());
        }
}