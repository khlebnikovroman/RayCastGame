using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RayCastGame
{
    public class Game1 : Game
    {
        private float ballSpeed;
        private readonly GraphicsDeviceManager _graphics;
        private Player player;
        private SpriteBatch _spriteBatch;
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private WorldMap map;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 300;
            player = new Player(ballPosition, ballSpeed);
            map = new WorldMap();
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ballTexture = Content.Load<Texture2D>("ball");
            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            var kstate = Keyboard.GetState();

            player.Move(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                player.Position,
                null,
                Color.White,
                player.Angle,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );
            //_spriteBatch.DrawLine(player.Position, 100f, player.Angle, Color.Black);
            RayCasting.RayCast(player, _spriteBatch);
            map.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}