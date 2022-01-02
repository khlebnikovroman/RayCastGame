using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RayCastGame
{
    internal class Tile : IDrawable
    {
        private readonly Vector2 coords;
        private readonly Vector2 size;


        public Tile(Vector2 coord, Vector2 size)
        {
            coords = coord;
            this.size = size;
        }


        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawRectangle(coords, size, Color.White);
        }
    }
}