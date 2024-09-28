using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class MudBombProjectile : BaseBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/MudBomb";


    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Mud, TileID.Mud);        
    }
}
