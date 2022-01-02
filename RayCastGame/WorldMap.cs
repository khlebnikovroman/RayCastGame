using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RayCastGame
{
    internal class WorldMap : IDrawable
    {
        private static readonly int height = 720;
        private static readonly int width = 1280;

        private static readonly string[] textMap =
        {
            "wwwwwwwwww",
            "w........w",
            "w........w",
            "w....w...w",
            "w....w...w",
            "w....w...w",
            "w....w...w",
            "w.w......w",
            "w.w......w",
            "wwwwwwwwww"
        };

        public List<Tile> Map;
        private readonly float tileheight = 72f;
        private readonly float tilewidth = 128f;
        private int mapSize = 10;


        public WorldMap()
        {
            Map = new List<Tile>();
            for (var i = 0; i < textMap.Length; i++)
            {
                for (var j = 0; j < textMap[i].Length; j++)
                {
                    if (textMap[i][j] == 'w')
                    {
                        var cord = new Vector2(j * tilewidth, i * tileheight);
                        var size = new Vector2(tilewidth, tileheight);

                        Map.Add(new Tile(cord, size));
                    }
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in Map)
            {
                tile.Draw(spriteBatch);
            }

            spriteBatch.DrawLine(0f, 0f, 50f, 50f, Color.Red);
        }
    }
}