using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class SandBombProjectile : BaseBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/SandBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Sand, TileID.Sand);
    }
}
