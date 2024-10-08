using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public enum BombType
{
    Normal,
    Sticky,
    Bouncy
}

public class MoreBombsItem(string name, int itemId, int itemCount, ModProjectile projectile, BombType type) : ModItem
{
    private readonly int _materialId = itemId;
    private readonly int _materialCount = itemCount;
    private readonly ModProjectile _projectile = projectile;
    private readonly BombType _type = type;

    public override string Name { get; } = name;

    protected override bool CloneNewInstances => true;

    public override void SetDefaults()
    {
        switch (_type)
        {
            case BombType.Normal:
                Item.CloneDefaults(ItemID.DirtBomb);
                break;

            case BombType.Sticky:
                Item.CloneDefaults(ItemID.DirtStickyBomb);
                break;

            case BombType.Bouncy:
                Item.CloneDefaults(ItemID.BouncyBomb);
                break;
        }

        Item.shoot = _projectile.Type;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(1)
            .AddIngredient(_materialId, _materialCount)
            .AddTile(TileID.WorkBenches);

        switch (_type)
        {
            case BombType.Normal:
                recipe.AddIngredient(ItemID.Bomb, 1);
                break;

            case BombType.Sticky:
                recipe.AddIngredient(ItemID.Gel, 1);
                break;

            case BombType.Bouncy:
                recipe.AddIngredient(ItemID.PinkGel, 1);
                break;
        }

        recipe.Register();
    }
}
