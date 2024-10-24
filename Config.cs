using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MoreBombs;

public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Bombs")]
    [DefaultValue(9)]
    public int BombExplosionWidth;

    [DefaultValue(9)]
    public int BombExplosionHeight;

    [DefaultValue(true)]
    public bool BombCircleExplosion;

    [Header("Dynamite")]
    [DefaultValue(9)]
    public int DynamiteExplosionWidth;

    [DefaultValue(9)]
    public int DynamiteExplosionHeight;

    [DefaultValue(true)]
    public bool DynamiteCircleExplosion;
}