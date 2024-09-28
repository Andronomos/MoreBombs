using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public class StickyAshBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtBomb);
        Item.shoot = ModContent.ProjectileType<StickyAshBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<AshBomb>(), 1)
            .AddIngredient(ItemID.Gel, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
