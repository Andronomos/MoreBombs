using MoreBombs.Content.Items;
using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs;

public class MoreBombs : Mod
{
    public override void Load()
    {
        CreateBomb("Snow", ItemID.SnowBlock, TileID.SnowBlock, DustID.SnowBlock);
        CreateBomb("Ash", ItemID.AshBlock, TileID.Ash, DustID.Ash);
        CreateBomb("Cloud", ItemID.Cloud, TileID.Cloud, DustID.Cloud);
        CreateBomb("Mud", ItemID.MudBlock, TileID.Mud, DustID.Mud);
        CreateBomb("Sand", ItemID.SandBlock, TileID.Sand, DustID.Sand);
        CreateBomb("Stone", ItemID.StoneBlock, TileID.Stone, DustID.Stone);
    }

    /// <summary>
    /// Creates the item and projectile
    /// </summary>
    /// <param name="name"></param>
    /// <param name="itemId">The item used in the recipe</param>
    /// <param name="tileId">The tile produced by the explosion</param>
    /// <param name="dustId">The dust produces by the explosion</param>
    /// <param name="itemCount">The number of items used in the recipe</param>
    /// <param name="isSticky">If the bomb is sticky</param>
    public void CreateBomb(string name, int itemId, ushort tileId, short dustId, int itemCount = 25)
    {
        string bombName = $"{name}Bomb";
        string stickyBombName = $"Sticky{bombName}";

        MoreBombsProjectile projectile = new(bombName, tileId, dustId, false);
        AddContent(projectile);
        MoreBombsItem bombItem = new(bombName, itemId, itemCount, projectile, false);
        AddContent(bombItem);

        MoreBombsProjectile stickyProjectile = new(stickyBombName, tileId, dustId, true);
        AddContent(stickyProjectile);        
        AddContent(new MoreBombsItem(stickyBombName, bombItem.Type, itemCount, stickyProjectile, true));
    }
}
