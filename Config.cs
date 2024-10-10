using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace MoreBombs;

public class Config : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("Bombs")]
    [DefaultValue(9)]
    public int ExplosionWidth;

    [DefaultValue(9)]
    public int ExplosionHeight;

    [DefaultValue(true)]
    public bool CircleExplosion;
}