using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class CloudBombProjectile : BaseBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/CloudBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Cloud, TileID.Cloud);
    }
}
