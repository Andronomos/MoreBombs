using MoreBombs.Content.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items
{
    public class StickyStoneBomb : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DirtStickyBomb);
            Item.shoot = ModContent.ProjectileType<StickyStoneBombProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ModContent.ItemType<StoneBomb>(), 1)
                .AddIngredient(ItemID.Bomb, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
