using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Managers {
    public static class CameraManager {
        public static Dictionary<string, OrthographicCamera> cameras = new Dictionary<string, OrthographicCamera>();
        public static OrthographicCamera activeCamera;

        private static GameWindow window;
        private static GraphicsDevice graphics;

        public static OrthographicCamera Initialize(GameWindow gameWindow, GraphicsDevice graphicsDevice) {
            window = gameWindow;
            graphics = graphicsDevice;
            activeCamera = CreateCamera();
            cameras.Add("Initial", activeCamera);
            return activeCamera;
        }

        public static void AddCamera(string key, OrthographicCamera camera) {
            cameras[key] = camera;
        }

        public static OrthographicCamera CreateCamera(int width, int height, Vector2 position) {
            width = width > 0 ? width : window.ClientBounds.Width;
            height = height > 0 ? height : window.ClientBounds.Height;

            BoxingViewportAdapter ViewportAdapter = new BoxingViewportAdapter(window, graphics, width, height);
            OrthographicCamera camera = new OrthographicCamera(ViewportAdapter);
            camera.Move(position + new Vector2(-(float)width/2, -(float)height/2));
            return camera;
        }

        public static OrthographicCamera CreateCamera(int width = 0, int height = 0) {
            return CreateCamera(width, height, new Vector2(0, 0));
        }

        public static OrthographicCamera CreateCamera(Vector2 position) {
            return CreateCamera(window.ClientBounds.Width, window.ClientBounds.Height, position);
        }

        public static OrthographicCamera CreateAndAddCamera(string key, int width, int height, Vector2 position) {
            OrthographicCamera camera = CreateCamera(width, height, position);
            AddCamera(key, camera);
            return camera;
        }

        public static OrthographicCamera CreateAndAddCamera(string key, int width = 0, int height = 0) {
            return CreateAndAddCamera(key, width, height, new Vector2(0, 0));
        }

        public static OrthographicCamera CreateAndAddCamera(string key, Vector2 position) {
            return CreateAndAddCamera(key, window.ClientBounds.Width, window.ClientBounds.Height, position);
        }

        public static OrthographicCamera GetCamera(string key) {
            return cameras[key];
        }

        public static void SetActiveCamera(string key) {
            activeCamera = GetCamera(key);
        }

        public static void SetActiveCamera(OrthographicCamera camera) {
            activeCamera = camera;
        }

        public static Matrix GetMatrix() {
            return activeCamera.GetViewMatrix();
        }

        public static void SetZoom(float zoom) {
            activeCamera.Zoom = zoom;
        }

        public static void ZoomIn(float deltaZoom) {
            activeCamera.ZoomIn(deltaZoom);
        }
        public static void ZoomOut(float deltaZoom) {
            activeCamera.ZoomOut(deltaZoom);
        }

        public static void Move(Vector2 vector2) {
            activeCamera.Move(vector2);
        }
    }
}
