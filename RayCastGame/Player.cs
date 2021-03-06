using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RayCastGame
{
    internal class Player
    {
        public float deltaAngle;
        public float fov = (int) (((Math.PI * 2) / 360) * 75);
        public readonly float speed;
        public readonly float turnSpeed;
        public int maxdepth = 800;
        public int numOfRays = 120;
        public Vector2 position;
        public float Angle { get; private set; }

        public Vector2 Position
        {
            get { return position; }
        }


        public Player(Vector2 pos, float speed)
        {
            position = pos;
            this.speed = speed;
            turnSpeed = 0.05f;
            deltaAngle = fov / numOfRays;
            Angle = -1.57f;
        }


        public void Move(GameTime time)
        {
            var sin_a = (float) Math.Sin(Angle);
            var cos_a = (float) Math.Cos(Angle);
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.W))
            {
                position.X += speed * cos_a * (float) time.ElapsedGameTime.TotalSeconds;
                position.Y += speed * sin_a * (float) time.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                position.X += -speed * cos_a * (float) time.ElapsedGameTime.TotalSeconds;
                position.Y += -speed * sin_a * (float) time.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                position.X += +speed * sin_a * (float) time.ElapsedGameTime.TotalSeconds;
                position.Y += -speed * cos_a * (float) time.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                position.X += -speed * sin_a * (float) time.ElapsedGameTime.TotalSeconds;
                position.Y += +speed * cos_a * (float) time.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                Angle -= turnSpeed;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                Angle += turnSpeed;
            }
        }
    }
}