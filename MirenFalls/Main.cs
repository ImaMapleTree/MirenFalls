using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using MirenFalls.Internal;
using MirenFalls.Internal.Map;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MirenFalls.Internal._TEST;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Core;

namespace MirenFalls {


    // IMPORTANT: Because we are making everything from scratch everything should be well(ish) documented and there shouldn't be much ambiguity between classes
    // A class should do what it's designed for and shouldn't implement unnecessary methods so that we increase the understanding of what each element in the code is supposed to do
    // For example my GameMap class is simply a map that holds the currently displayed tile data and a rendering function. Other methods will be invoked on the GameMap but the GameMap
    // Should not be the one invoking those methods.

    // THIS CLASS IS GOING TO BE AN ABSOLUTE MESS BECAUSE I WAS DOING A LOT OF TESTING HERE
    // FEEL FREE TO CLEAN IT UP

    public class Main : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameMap map;
        private Internal.Utils.FrameCounter _frameCounter = new Internal.Utils.FrameCounter();
        private OrthographicCamera _camera;
        private MouseState clickState;
        private Random rng = new Random();

        public Main() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            map = new GameMap(1000, 1000); // NOTE: 1000 x 1000 is REALLY big but it's for testing purposes
        }

        protected override void Initialize() {
            int width = 1366;
            int height = 768;
            _graphics.PreferredBackBufferHeight = height;
            _graphics.PreferredBackBufferWidth = width;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            var ViewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, width, height);
            _camera = new OrthographicCamera(ViewportAdapter);
            _camera.ZoomOut(0.955f); // Good settings for viewing the whole map
            _camera.Move(new Vector2(5000, 8000));
            //_camera.ZoomIn(1.3f);

            Pipeline.Initialize(_graphics.GraphicsDevice);
            Resources.Initialize(Content, _graphics.GraphicsDevice); // Passes the content manager to Resources to allow for loading from the content manager




            map.Initialize("rawr");

            
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.loadStatic();
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState currentState = Mouse.GetState();

            if (currentState.LeftButton == ButtonState.Pressed && clickState.LeftButton == ButtonState.Released) {
                map.Initialize(rng.Next().ToString());
            }

            clickState = currentState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);

            Window.Title = fps;

            map.Draw(_spriteBatch);

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
