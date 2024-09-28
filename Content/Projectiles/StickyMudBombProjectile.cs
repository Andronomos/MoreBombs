using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickyMudBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickyMudBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Mud, TileID.Mud);
    }
}
