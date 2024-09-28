using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class SnowBombProjectile : BaseBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/SnowBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.SnowBlock, TileID.SnowBlock);
    }
}
