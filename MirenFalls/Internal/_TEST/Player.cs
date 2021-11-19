using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MirenFalls.Internal.Utils;
using MonoGame.Extended.Content;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Sprites;
using System.IO;
using System.Text;

namespace MirenFalls.Internal._TEST {

    // TEST IMPLEMENTATION OF A PLAYER
    // MORE OR LESS USED FOR CODING & TESTING "DYNAMIC" PROCEDURAL GENERATION
    
    public class Player {

        public float walkSpeed = 100;

        public AnimatedSprite sprite;
        protected Vector2 position;

        string lastDirection = "South";

        public Player(string name_id, Vector2 position) {
            SpriteSheet spriteSheet = Resources.loadContent<SpriteSheet>("Animations/Characters/sophia");

            Debug.Log(spriteSheet.Cycles);

            sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("idleEast");

            this.position = position;
        }

        public void MoveUpdate(GameTime gameTime, KeyboardState keyState) {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.W)) {
                sprite.Play("walkNorth");
                lastDirection = "North";
                position.Y -= walkSpeed * deltaTime;
            } else if (keyState.IsKeyDown(Keys.S)) {
                sprite.Play("walkSouth");
                lastDirection = "South";
                position.Y += walkSpeed * deltaTime;
            } else if (keyState.IsKeyDown(Keys.A)) {
                sprite.Play("walkWest");
                lastDirection = "West";
                position.X -= walkSpeed * deltaTime;
            } else if (keyState.IsKeyDown(Keys.D)) {
                sprite.Play("walkEast");
                lastDirection = "East";
                position.X += walkSpeed * deltaTime;
            } else if (lastDirection.Equals("North") && keyState.IsKeyUp(Keys.W)) {
                sprite.Play("idleNorth");
            } else if (lastDirection.Equals("South") && keyState.IsKeyUp(Keys.S)) {
                sprite.Play("idleSouth");
            } else if (lastDirection.Equals("West") && keyState.IsKeyUp(Keys.A)) {
                sprite.Play("idleWest");
            } else if (lastDirection.Equals("East") && keyState.IsKeyUp(Keys.D)) {
                sprite.Play("idleEast");
            }


            sprite.Update(deltaTime);

        }

        public void Draw(SpriteBatch spriteBatch) {
            sprite.Draw(spriteBatch, position, 0, new Vector2(1, 1));
        }
    }
}
