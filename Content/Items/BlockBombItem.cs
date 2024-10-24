using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Items;

public enum ExplosiveType
{
    Bomb,
    Dynamite
}

public enum ExplosiveBehaviour
{
    Normal,
    Sticky,
    Bouncy
}

public class BlockBombItem(string name, int materialId, int materialCount, ModProjectile projectile, ExplosiveType type, ExplosiveBehaviour behaviour) : ModItem
{
    private readonly int _materialId = materialId;
    private readonly int _materialCount = materialCount;
    private readonly ModProjectile _projectile = projectile;
    private readonly ExplosiveType _type = type;
    private readonly ExplosiveBehaviour _behaviour = behaviour;

    public override string Name { get; } = name;

    protected override bool CloneNewInstances => true;

    public override void SetDefaults()
    {
        switch (_type)
        {
            case ExplosiveType.Bomb:                
                switch (_behaviour)
                {
                    case ExplosiveBehaviour.Normal:
                        Item.CloneDefaults(ItemID.DirtBomb);
                        break;

                    case ExplosiveBehaviour.Sticky:
                        Item.CloneDefaults(ItemID.StickyBomb);
                        break;

                    case ExplosiveBehaviour.Bouncy:
                        Item.CloneDefaults(ItemID.BouncyBomb);
                        break;
                    default:
                        break;
                }
                break;

            case ExplosiveType.Dynamite:
                switch (_behaviour)
                {
                    case ExplosiveBehaviour.Normal:
                        Item.CloneDefaults(ItemID.Dynamite);
                        break;

                    case ExplosiveBehaviour.Sticky:
                        Item.CloneDefaults(ItemID.StickyDynamite);
                        break;

                    case ExplosiveBehaviour.Bouncy:
                        Item.CloneDefaults(ItemID.BouncyDynamite);
                        break;
                    default:
                        break;
                }
                break;
        }

        Item.shoot = _projectile.Type;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(1)
            .AddIngredient(_materialId, _materialCount)
            .AddTile(TileID.WorkBenches);

        switch (_behaviour)
        {
            case ExplosiveBehaviour.Normal:
                switch (_type)
                {
                    case ExplosiveType.Bomb:
                        recipe.AddIngredient(ItemID.Bomb, 1);
                        break;
                    case ExplosiveType.Dynamite:
                        recipe.AddIngredient(ItemID.Dynamite, 1);
                        break;
                }
                
                break;

            case ExplosiveBehaviour.Sticky:
                recipe.AddIngredient(ItemID.Gel, 1);
                break;

            case ExplosiveBehaviour.Bouncy:
                recipe.AddIngredient(ItemID.PinkGel, 1);
                break;
            default:
                break;
        }

        recipe.Register();
    }
}
