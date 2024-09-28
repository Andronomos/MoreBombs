using MoreBombs.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public class MudBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtBomb);
        Item.shoot = ModContent.ProjectileType<MudBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.MudBlock, 25)
            .AddIngredient(ItemID.Bomb, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
