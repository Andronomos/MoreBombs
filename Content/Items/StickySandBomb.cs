using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using MoreBombs.Content.Projectiles;

namespace MoreBombs.Content.Items;

public class StickySandBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtStickyBomb);
        Item.shoot = ModContent.ProjectileType<StickySandBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<SandBomb>(), 1)
            .AddIngredient(ItemID.Gel, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
