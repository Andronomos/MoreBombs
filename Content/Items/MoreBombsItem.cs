using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public class MoreBombsItem(string name, int itemId, int itemCount, ModProjectile projectile, bool isSticky) : ModItem
{
    private readonly int _materialId = itemId;
    private readonly int _materialCount = itemCount;
    private readonly ModProjectile _projectile = projectile;
    private readonly bool _isSticky = isSticky;

    public override string Name { get; } = name;

    protected override bool CloneNewInstances => true;

    public override void SetDefaults()
    {
        Item.CloneDefaults(_isSticky ? ItemID.DirtStickyBomb : ItemID.DirtBomb);
        Item.shoot = _projectile.Type;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(_materialId, _materialCount)
            .AddIngredient(_isSticky ? ItemID.Gel : ItemID.Bomb, 1)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}
