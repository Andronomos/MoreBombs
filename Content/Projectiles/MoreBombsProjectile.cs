using Microsoft.Xna.Framework;
using MoreBombs.Content.Items;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoreBombs.Content.Projectiles;

public class MoreBombsProjectile(string name, ushort tileId, short dustId, BombType type) : ModProjectile
{
    private const int DustParticleCount = 30;
    private const int BlockParticleCount = 80;

    public override string Name { get; } = name;

    public override string Texture => $"MoreBombs/Content/Items/{Name}";

    protected override bool CloneNewInstances => true;

    public override void SetDefaults()
    {
        switch (type)
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
        if (type == BombType.Sticky)
        {
            Projectile.velocity = Vector2.Zero;
            Projectile.aiStyle = 0;
            return false;
        }

        if (type == BombType.Bouncy)
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

        ExplodeAndPlaceTiles(dustId, tileId);
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
      
        PlaceTiles(tileId);         
    }

    public (int, int) CalculateRadiusValues(int desiredRadius)
    {
        if (desiredRadius <= 0)
        {
            desiredRadius = 2;
        }

        int minRadius = desiredRadius / 2;
        int maxRadius = minRadius;

        //if the desired radius is an odd number, add 1 to the radius to account for 0
        if (desiredRadius % 2 != 0)
        {
            maxRadius += 1;
        }

        return (minRadius, maxRadius);
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

    private void PlaceTiles(int tileId)
    {
        (int minWidth, int maxWidth) = CalculateRadiusValues(ModContent.GetInstance<Config>().ExplosionWidth);
        (int miHeight, int maxHeight) = CalculateRadiusValues(ModContent.GetInstance<Config>().ExplosionHeight);

        for (int x = -minWidth; x < maxWidth; x++)
        {
            for (int y = -miHeight; y < maxHeight; y++)
            {
                int tileX = (int)(Projectile.position.X / 16f) + x;
                int tileY = (int)(Projectile.position.Y / 16f) + y;

                if (ModContent.GetInstance<Config>().CircleExplosion)
                {
                    if ((x * x) + (y * y) > minWidth * minWidth) // Check if within circle
                    {
                        continue;
                    }
                }

                WorldGen.PlaceTile(tileX, tileY, tileId);
            }
        }
    }
}
