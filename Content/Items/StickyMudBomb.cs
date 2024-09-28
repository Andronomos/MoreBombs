using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace MoreBombs.Content.Items;

public class StickyMudBomb : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.DirtBomb);
        Item.shoot = ModContent.ProjectileType<StickyMudBombProjectile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<MudBomb>(), 1)
            .AddIngredient(ItemID.Gel, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
