using BiomeExpansion.Content.Biomes;
using Terraria.GameContent;
using Terraria.Graphics.Effects;

namespace BiomeExpansion.Content.Skies;

public class CrimsonSky : CustomSky
{
    private bool _isActive;
    private float _intensity;

    public override void Update(GameTime gameTime)
    {
        if (!Main.LocalPlayer.InModBiome<CrimsonInfectedMushroomSurfaceBiome>() || Main.gameMenu) 
            _isActive = false;

        if (_isActive)
        {
            _intensity += 0.01f;
            if (_intensity > 1f)
            {
                _intensity = 1f;
            }
        }
        else
        {
            _intensity -= 0.01f;
            if (_intensity < 0f)
            {
                _intensity = 0f;
            }
        }
    }

    public override Color OnTileColor(Color inColor)
    {
        return Color.Lerp(inColor, new Color(180, 20, 20), _intensity * 0.5f);
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
        if (_intensity > 0f && minDepth == float.MinValue && maxDepth == float.MaxValue)
        {
            Color skyColor = new Color(180, 20, 20);  // Corruption-like purple
            spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), skyColor * _intensity);
        }
    }

    public override float GetCloudAlpha()
    {
        return 1f - _intensity;
    }

    public override void Activate(Vector2 position, params object[] args)
    {
        _isActive = true;
    }

    public override void Deactivate(params object[] args)
    {
        _isActive = false;
    }

    public override bool IsActive()
    {
        return _isActive || _intensity > 0f;
    }

    public override void Reset()
    {
        _isActive = false;
        _intensity = 0f;
    }
}