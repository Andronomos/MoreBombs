using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class AshBombProjectile : BaseBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/AshBomb";


    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Ash, TileID.Ash);
    }
}
