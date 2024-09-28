using Microsoft.Xna.Framework;
using Terraria.Chat;
using Terraria.Localization;

namespace MoreBombs;

public static class BroadcastUtils
{
    public static void BroadcastError(string message)
    {
        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), Color.Red);
    }

    public static void BroadcastInfo(string message)
    {
        ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), Color.Yellow);
    }
}
