using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickySandBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickySandBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Sand, TileID.Sand);
    }
}
