using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MirenFalls.Internal;
using MirenFalls.Internal.Map;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Managers;
using MirenFalls.Internal.Utils;

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
        private System.Random rng = new System.Random();
        private string cameraKey = "Initial";

        private OrthographicCamera mainCamera;
        private OrthographicCamera largeCamera;

        private Player sophia;
        private VectorInt lastPos;

        private int mapWidth;
        private int mapHeight;


        public Main() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            mapWidth = 50;
            mapHeight = 50;


            map = new GameMap(mapWidth, mapHeight); // NOTE: 1000 x 1000 is REALLY big but it's for testing purposes
        }

        protected override void Initialize() {
            int width = 1366;
            int height = 1000; //768
            _graphics.PreferredBackBufferHeight = height;
            _graphics.PreferredBackBufferWidth = width;
            _graphics.ApplyChanges();

            Pipeline.Initialize(_graphics.GraphicsDevice);
            Resources.Initialize(Content, _graphics.GraphicsDevice); // Passes the content manager to Resources to allow for loading from the content manager


            GameSettings.Initialize();


            mainCamera = CameraManager.Initialize(Window, GraphicsDevice);
            mainCamera.Move(new Vector2(500, 500));
            mainCamera.ZoomOut(0.2f);

            largeCamera = CameraManager.CreateCamera();

            largeCamera.ZoomOut(0.955f); // Good settings for viewing the whole map
            largeCamera.Move(new Vector2(5000, 8000));

            //CameraManager.AddCamera("Initial", largeCamera);



            map.Initialize("rawr");


            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.loadStatic();

            sophia = new Player("sophia", new Vector2(mapWidth*8, mapHeight*8));
            lastPos = sophia.tilePosition;
        }

        protected override void Update(GameTime gameTime) {
            KeyboardState keyState = Keyboard.GetState();

            float cameraSpeed = 400;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState currentState = Mouse.GetState();
            

            if (currentState.LeftButton == ButtonState.Pressed && clickState.LeftButton == ButtonState.Released) {
                //map.Initialize(rng.Next().ToString());
                map.Shift(new VectorInt(0, 1));
            }

            if (currentState.RightButton == ButtonState.Pressed && clickState.RightButton == ButtonState.Released) {
                CameraManager.SetActiveCamera(cameraKey);
                if (cameraKey.Equals("Player2")) cameraKey = "Initial";
                else if (cameraKey.Equals("Initial")) cameraKey = "Player";
                else cameraKey = "Player2";
            }

            if (keyState.IsKeyDown(Keys.LeftShift)) {
                cameraSpeed = 800;
            }

            if (keyState.IsKeyDown(Keys.Left)) {
                mainCamera.Move(new Vector2(-cameraSpeed * deltaTime, 0));
            } 
            if (keyState.IsKeyDown(Keys.Right)) {
                mainCamera.Move(new Vector2(cameraSpeed * deltaTime, 0));
            } 
            if (keyState.IsKeyDown(Keys.Up)) {
                mainCamera.Move(new Vector2(0, -cameraSpeed * deltaTime));
            }
            if (keyState.IsKeyDown(Keys.Down)) {
                mainCamera.Move(new Vector2(0, cameraSpeed * deltaTime));
            }

            clickState = currentState;

            sophia.MoveUpdate(gameTime, keyState);

            if (sophia.tilePosition != lastPos) {
                map.Shift(sophia.tilePosition - lastPos);
            }

            lastPos = sophia.tilePosition;

            _frameCounter.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(transformMatrix: CameraManager.GetMatrix(), samplerState: SamplerState.PointClamp);

            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);

            Window.Title = fps;

            map.Draw(_spriteBatch);
            sophia.Draw(_spriteBatch);

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
