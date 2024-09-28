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
    public class StoneBomb : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DirtBomb);
            Item.shoot = ModContent.ProjectileType<StoneBombProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(1)
                .AddIngredient(ItemID.StoneBlock, 25)
                .AddIngredient(ItemID.Bomb, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
