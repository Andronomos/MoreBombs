using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickyAshBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickyAshBomb";
    
    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Ash, TileID.Ash);
    }
}
