﻿using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Biomes {
    public class TestDroplet : ModGore
    {
        public override void SetStaticDefaults()
        {
            ChildSafety.SafeGore[Type] = true;
            GoreID.Sets.LiquidDroplet[Type] = true;
            UpdateType = GoreID.WaterDrip;
        }
    }
}