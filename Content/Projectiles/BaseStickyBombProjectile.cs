using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MoreBombs.Content.Projectiles;

public class BaseStickyBombProjectile : BaseBombProjectile
{
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.DirtStickyBomb);
        Projectile.timeLeft = 180;
        Projectile.tileCollide = true;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.velocity = Vector2.Zero;
        Projectile.aiStyle = 0;
        return false;
    }
}
