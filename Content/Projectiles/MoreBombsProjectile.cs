using Microsoft.Xna.Framework;
using MoreBombs.Content.Items;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs.Content.Projectiles;

public class MoreBombsProjectile(string name, ushort tileId, short dustId, BombType type) : ModProjectile
{
    private const int DustParticleCount = 30;
    private const int BlockParticleCount = 80;
    private const int ExplosionRadius = 4;
    private readonly ushort _tileId = tileId;
    private readonly short _dustId = dustId;
    private readonly BombType _type = type;

    public override string Name { get; } = name;

    public override string Texture => $"MoreBombs/Content/Items/{Name}";

    protected override bool CloneNewInstances => true;

    public override void SetDefaults()
    {
        switch (_type)
        {
            case BombType.Normal:
                Projectile.CloneDefaults(ProjectileID.DirtBomb);
                break;

            case BombType.Sticky:
                Projectile.CloneDefaults(ProjectileID.DirtStickyBomb);
                Projectile.tileCollide = true;
                break;

            case BombType.Bouncy:
                Projectile.CloneDefaults(ProjectileID.BouncyBomb);
                break;
        }

        Projectile.timeLeft = 180;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (_type == BombType.Sticky)
        {
            Projectile.velocity = Vector2.Zero;
            Projectile.aiStyle = 0;
            return false;
        }

        if (_type == BombType.Bouncy)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }

            return false; // Prevents the projectile from being destroyed
        }

        return true;
    }

    public override void OnKill(int timeLeft)
    {
        Projectile.Resize(22, 22);

        //play the bomb explosion sound
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

        //render smoke particles
        for (int i = 0; i < DustParticleCount; i++)
        {
            Dust dust51 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, Color.Transparent, 1.5f);
            Dust dust2 = dust51;
            dust2.velocity *= 1.4f;
        }

        ExplodeAndPlaceTiles(_dustId, _tileId);
    }

    public void ExplodeAndPlaceTiles(int dustId, int tileId)
    {
        //render the block particles
        for (int i = 0; i < BlockParticleCount; i++)
        {
            int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustId);
            Main.dust[dustIndex].velocity *= 1.4f;
        }

        if (PlayerInTheWay())
        {
            return;
        }

        PlaceTilesInCircle(tileId);
    }

    public bool PlayerInTheWay()
    {
        foreach (Player player in Main.player)
        {
            if (player.active && player.Hitbox.Intersects(new Rectangle((int)(Projectile.position.X), (int)(Projectile.position.Y), 16, 16)))
            {
                return true;
            }
        }

        return false;
    }

    private void PlaceTilesInSquare(int tileId)
    {
        for (int x = -ExplosionRadius; x <= ExplosionRadius; x++)
        {
            for (int y = -ExplosionRadius; y <= ExplosionRadius; y++)
            {
                int tileX = (int)(Projectile.position.X / 16f) + x;
                int tileY = (int)(Projectile.position.Y / 16f) + y;
                WorldGen.PlaceTile(tileX, tileY, tileId);
            }
        }
    }

    private void PlaceTilesInCircle(int tileId)
    {
        for (int x = -ExplosionRadius; x <= ExplosionRadius; x++)
        {
            for (int y = -ExplosionRadius; y <= ExplosionRadius; y++)
            {
                if (x * x + y * y <= ExplosionRadius * ExplosionRadius) // Check if within circle
                {
                    int tileX = (int)(Projectile.position.X / 16f) + x;
                    int tileY = (int)(Projectile.position.Y / 16f) + y;

                    WorldGen.PlaceTile(tileX, tileY, tileId);
                }
            }
        }
    }
}
