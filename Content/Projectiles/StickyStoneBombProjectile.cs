using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class StickyStoneBombProjectile : BaseStickyBombProjectile
{
    public override string Texture => "MoreBombs/Content/Items/StickyStoneBomb";

    public override void OnKill(int timeLeft)
    {
        base.OnKill(timeLeft);
        ExplodeAndPlaceTiles(DustID.Stone, TileID.Stone);
    }
}
