using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RayCastGame
{
    internal static class RayCasting
    {
        public static void RayCast(Player player, SpriteBatch spriteBatch)
        {
            var curAngle = player.Angle - (player.fov / 2f);
            for (var i = 0; i < player.numOfRays; i++)
            {
                var sin_a = Math.Sin(curAngle);
                var cos_a = Math.Cos(curAngle);

                //spriteBatch.DrawLine(player.Position, depth, curAngle, Color.Red);

                for (var depth = 0; depth < player.maxdepth; depth++)
                {
                    var x = (float) (player.Position.X + (depth * cos_a));
                    var y = (float) (player.Position.Y + (depth * sin_a));
                    spriteBatch.DrawLine(player.Position, new Vector2(x, y), Color.Red);
                }

                curAngle += player.deltaAngle;
            }
        }
    }
}