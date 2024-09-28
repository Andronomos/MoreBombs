using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickySnowBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickySnowBomb";
    
    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.SnowBlock, TileID.SnowBlock);
    }
}
