using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Core {
    public static class Pipeline {

        public static PipelineGame internalGame;

        public static bool Initialized = false;

        private static GraphicsDevice _graphicsDevice;

        public static GraphicsDevice graphicsDevice { 
            set { _graphicsDevice = value; }
            get {
                if (_graphicsDevice == null) {
                    Pipeline.Initialize();
                }
                return _graphicsDevice;
            } 
        }

        public static void Initialize(GraphicsDevice graphics = null) {
            if (!Initialized) {
                Initialized = true;
                _graphicsDevice = graphics;
                if (graphics == null) {
                    internalGame = new PipelineGame();
                    internalGame.RunOneFrame();
                    _graphicsDevice = internalGame.graphicsDevice;
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
