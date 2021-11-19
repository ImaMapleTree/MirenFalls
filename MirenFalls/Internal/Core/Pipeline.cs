using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Core {
    public static class Pipeline {

        public static PipelineGame internalGame = new PipelineGame();

        public static bool Initialized = false;


        public static GraphicsDevice graphicsDevice = internalGame.GraphicsDevice;

        public static void Initialize(GraphicsDevice graphics = null) {
            if (!Initialized) {
                Initialized = true;
                graphicsDevice = graphics;
                if (graphics == null) {
                    internalGame.RunOneFrame();
                    graphicsDevice = internalGame.graphicsDevice;
                }
            }
        }

        public class PipelineGame : Game {
            public GraphicsDeviceManager graphics;
            public GraphicsDevice graphicsDevice;

            public PipelineGame() {
                graphics = new GraphicsDeviceManager(this);
            }

            protected override void Initialize() {
                graphicsDevice = graphics.GraphicsDevice;
                base.Initialize();
            }
        }
    }
}
