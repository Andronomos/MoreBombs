using MoreBombs.Content;
using MoreBombs.Content.Items;
using MoreBombs.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBombs;

public class MoreBombs : Mod
{
    public override void Load()
    {
        //This bomb only exists because you can't apply the config settings to the vanilla dirt bomb
        CreateBomb("Dirt", ItemID.DirtBlock, TileID.Dirt, DustID.Dirt);
        CreateDynamite("Dirt", ItemID.DirtBlock, TileID.Dirt, DustID.Dirt);

        CreateBomb("Snow", ItemID.SnowBlock, TileID.SnowBlock, DustID.SnowBlock);
        CreateBomb("Ash", ItemID.AshBlock, TileID.Ash, DustID.Ash);
        CreateBomb("Cloud", ItemID.Cloud, TileID.Cloud, DustID.Cloud);
        CreateBomb("Mud", ItemID.MudBlock, TileID.Mud, DustID.Mud);
        CreateBomb("Sand", ItemID.SandBlock, TileID.Sand, DustID.Sand);
        CreateBomb("Stone", ItemID.StoneBlock, TileID.Stone, DustID.Stone);
        CreateBomb("Ebonstone", ItemID.EbonstoneBlock, TileID.Ebonstone, DustID.Stone);
        CreateBomb("Ebonsand", ItemID.EbonsandBlock, TileID.Ebonsand, DustID.Sand);
        CreateBomb("Pearlsand", ItemID.PearlsandBlock, TileID.Pearlsand, DustID.Pearlsand);
        CreateBomb("Pearlstone", ItemID.PearlstoneBlock, TileID.Pearlstone, DustID.Sand);
        CreateBomb("Crimstone", ItemID.CrimstoneBlock, TileID.Crimstone, DustID.Crimstone);
        CreateBomb("Crimsand", ItemID.CrimsandBlock, TileID.Crimsand, DustID.Crimstone);
    }

    /// <summary>
    /// Creates the item and projectile
    /// </summary>
    /// <param name="name"></param>
    /// <param name="itemId">The item used in the recipe</param>
    /// <param name="tileId">The tile produced by the explosion</param>
    /// <param name="dustId">The dust produces by the explosion</param>
    /// <param name="itemCount">The number of items used in the recipe</param>
    public void CreateBomb(string name, int itemId, ushort tileId, short dustId, int itemCount = 25)
    {
        string bombName = $"{name}Bomb";
        string stickyBombName = $"Sticky{bombName}";
        string bouncyBombName = $"Bouncy{bombName}";

        BlockExplosiveProjectile projectile = new(bombName, tileId, dustId, ExplosiveType.Bomb, ExplosiveBehaviour.Normal);
        AddContent(projectile);
        BlockBombItem bombItem = new(bombName, itemId, itemCount, projectile, ExplosiveType.Bomb, ExplosiveBehaviour.Normal);
        AddContent(bombItem);

        BlockExplosiveProjectile stickyProjectile = new(stickyBombName, tileId, dustId, ExplosiveType.Bomb, ExplosiveBehaviour.Sticky);
        AddContent(stickyProjectile);        
        AddContent(new BlockBombItem(stickyBombName, bombItem.Type, 1, stickyProjectile, ExplosiveType.Bomb, ExplosiveBehaviour.Sticky));

        BlockExplosiveProjectile bouncyProjectile = new(bouncyBombName, tileId, dustId, ExplosiveType.Bomb, ExplosiveBehaviour.Bouncy);
        AddContent(bouncyProjectile);
        AddContent(new BlockBombItem(bouncyBombName, bombItem.Type, 1, bouncyProjectile, ExplosiveType.Bomb, ExplosiveBehaviour.Bouncy));
    }


    public void CreateDynamite(string name, int itemId, ushort tileId, short dustId, int itemCount = 25)
    {
        string bombName = $"{name}Dynamite";
        string stickyBombName = $"Sticky{bombName}";
        string bouncyBombName = $"Bouncy{bombName}";

        BlockExplosiveProjectile projectile = new(bombName, tileId, dustId, ExplosiveType.Dynamite, ExplosiveBehaviour.Normal);
        AddContent(projectile);
        BlockBombItem bombItem = new(bombName, itemId, itemCount, projectile, ExplosiveType.Dynamite, ExplosiveBehaviour.Normal);
        AddContent(bombItem);

        BlockExplosiveProjectile stickyProjectile = new(stickyBombName, tileId, dustId, ExplosiveType.Dynamite, ExplosiveBehaviour.Sticky);
        AddContent(stickyProjectile);
        AddContent(new BlockBombItem(stickyBombName, bombItem.Type, 1, stickyProjectile, ExplosiveType.Dynamite, ExplosiveBehaviour.Sticky));

        BlockExplosiveProjectile bouncyProjectile = new(bouncyBombName, tileId, dustId, ExplosiveType.Dynamite, ExplosiveBehaviour.Bouncy);
        AddContent(bouncyProjectile);
        AddContent(new BlockBombItem(bouncyBombName, bombItem.Type, 1, bouncyProjectile, ExplosiveType.Dynamite, ExplosiveBehaviour.Bouncy));
    }
}
