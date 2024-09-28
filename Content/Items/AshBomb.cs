using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public class AshBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtBomb);
        Item.shoot = ModContent.ProjectileType<AshBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.AshBlock, 25)
            .AddIngredient(ItemID.Bomb, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
