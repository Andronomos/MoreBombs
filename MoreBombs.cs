using MoreBombs.Content.Items;
using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs;

public class MoreBombs : Mod
{
    public override void Load()
    {
        RegisterBomb("Snow", ItemID.SnowBlock, TileID.SnowBlock, DustID.SnowBlock);
        RegisterBomb("Ash", ItemID.AshBlock, TileID.Ash, DustID.Ash);
        RegisterBomb("Cloud", ItemID.Cloud, TileID.Cloud, DustID.Cloud);
        RegisterBomb("Mud", ItemID.MudBlock, TileID.Mud, DustID.Mud);
        RegisterBomb("Sand", ItemID.SandBlock, TileID.Sand, DustID.Sand);
        RegisterBomb("Stone", ItemID.StoneBlock, TileID.Stone, DustID.Stone);
    }

    private void RegisterBomb(string name, short itemId, ushort tileId, short dustId)
    {
        ModItem bomb = AddBomb(name, itemId, tileId, dustId, 25);
        AddBomb($"Sticky{name}", bomb.Type, tileId, dustId, 1, true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="itemId">The item used in the recipe</param>
    /// <param name="tileId">The tile produced by the explosion</param>
    /// <param name="dustId">The dust produces by the explosion</param>
    /// <param name="itemCount">The number of items used in the recipe</param>
    /// <param name="isSticky">If the bomb is sticky</param>
    public ModItem AddBomb(string name, int itemId, ushort tileId, short dustId, int itemCount = 25, bool isSticky = false)
    {
        string bombName = $"{name}Bomb";

        MoreBombsProjectile projectile = new(bombName, tileId, dustId, isSticky);
        AddContent(projectile);
        MoreBombsItem bombItem = new(bombName, itemId, itemCount, projectile, isSticky);
        AddContent(bombItem);

        return bombItem;
    }
}
