using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickyCloudBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickyCloudBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Cloud, TileID.Cloud);
    }
}
