using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoreBombs.Content.Items;

public class CloudBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtBomb);
        Item.shoot = ModContent.ProjectileType<CloudBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.Cloud, 25)
            .AddIngredient(ItemID.Bomb, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
