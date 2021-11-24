using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Managers;
using MonoGame.Extended;

namespace MirenFalls.Internal.Core {

    // TEST IMPLEMENTATION OF A PLAYER
    // MORE OR LESS USED FOR CODING & TESTING "DYNAMIC" PROCEDURAL GENERATION

    public class Player {

        public float walkSpeed = 60;
        public Animation sprite;
        public Vector2 position;
        public VectorInt tilePosition;


        public OrthographicCamera playerCamera;
        public OrthographicCamera testCamera;



        string lastDirection = "South";

        public Player(string name_id, Vector2 position) {
            sprite = Resources.loadContent<Animation>("Animations/Characters/sophia");
            sprite.Play("idleEast");

            this.position = position;
            tilePosition = Utils.Utilities.TilePosition(position);

            playerCamera = CameraManager.CreateCamera(position+sprite.Center);
            playerCamera.ZoomIn(3f); //~4
            CameraManager.AddCamera("Player", playerCamera);
            CameraManager.SetActiveCamera("Player");

            testCamera = CameraManager.CreateCamera(position + sprite.Center);
            testCamera.ZoomIn(0.15f); //~4
            CameraManager.AddCamera("Player2", testCamera);
        }

        public void MoveUpdate(GameTime gameTime, KeyboardState keyState) {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            bool moving = false;

            if (keyState.IsKeyDown(Keys.LeftShift)) {
                sprite.SetFrameDuration(0.6f);
                walkSpeed = 300; //~100
            } else {
                sprite.SetFrameDuration(0.8f);
                walkSpeed = 60;
            }

            if (keyState.IsKeyDown(Keys.W)) {
                sprite.Play("walkNorth");
                lastDirection = "North";
                position.Y -= walkSpeed * deltaTime;
                playerCamera.Move(new Vector2(0, -walkSpeed * deltaTime));
                testCamera.Move(new Vector2(0, -walkSpeed * deltaTime));
                moving = true;
            } 
            if (keyState.IsKeyDown(Keys.S)) {
                sprite.Play("walkSouth");
                lastDirection = "South";
                position.Y += walkSpeed * deltaTime;
                playerCamera.Move(new Vector2(0, walkSpeed * deltaTime));
                testCamera.Move(new Vector2(0, walkSpeed * deltaTime));
                moving = true;
            } 
            if (keyState.IsKeyDown(Keys.A)) {
                sprite.Play("walkWest");
                lastDirection = "West";
                position.X -= walkSpeed * deltaTime;
                playerCamera.Move(new Vector2(-walkSpeed * deltaTime, 0));
                testCamera.Move(new Vector2(-walkSpeed * deltaTime, 0));
                moving = true;
            } 
            if (keyState.IsKeyDown(Keys.D)) {
                sprite.Play("walkEast");
                lastDirection = "East";
                position.X += walkSpeed * deltaTime;
                playerCamera.Move(new Vector2(walkSpeed * deltaTime, 0));
                testCamera.Move(new Vector2(walkSpeed * deltaTime, 0));
                moving = true;
            } 

            if (!moving && lastDirection.Equals("North") && keyState.IsKeyUp(Keys.W)) {
                sprite.Play("idleNorth");
            } else if (!moving && lastDirection.Equals("South") && keyState.IsKeyUp(Keys.S)) {
                sprite.Play("idleSouth");
            } else if (!moving && lastDirection.Equals("West") && keyState.IsKeyUp(Keys.A)) {
                sprite.Play("idleWest");
            } else if (!moving && lastDirection.Equals("East") && keyState.IsKeyUp(Keys.D)) {
                sprite.Play("idleEast");
            }

            tilePosition = Utils.Utilities.TilePosition(position);


            sprite.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch) {
            sprite.Draw(spriteBatch, position);
        }
    }
}
