using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoreBombs.Content.Items;

public class StickyCloudBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtStickyBomb);
        Item.shoot = ModContent.ProjectileType<Projectiles.StickyCloudBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<SnowBomb>(), 1)
            .AddIngredient(ItemID.Gel, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
