using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MoreBombs;

public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("General")]
    [DefaultValue(true)]
    public bool CircleExplosion;

    [Header("Bombs")]
    [DefaultValue(9)]
    public int BombExplosionWidth;

    [DefaultValue(9)]
    public int BombExplosionHeight;

    [Header("Dynamite")]
    [DefaultValue(15)]
    public int DynamiteExplosionWidth;

    [DefaultValue(15)]
    public int DynamiteExplosionHeight;    
}