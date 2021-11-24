using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Graphics {
    public class Animation {

        private SpriteSheet _sheet;
        private TextureRegion _currentTexture;
        private AnimationCycle _currentCycle;
        private float frameIndex;
        private float override_duration;
        private Vector2 _center;

        public Vector2 Center { get { return _center; } }

        public SpriteSheet textureAtlas {
            get { return _sheet; }
            set {
                _sheet = value;
                _currentTexture = _sheet.GetSprite(0);
                _center = new Vector2(_sheet.regionWidth / 2, _sheet.regionHeight / 1.95f);
            }
        }

        public Dictionary<string, AnimationCycle> cycles { get; set; }

        public TextureRegion currentTexture {
            get { return _currentTexture; }
        }

        public AnimationCycle currentCycle { get { return _currentCycle; } }


        public Animation() {
        }

        public Animation(SpriteSheet sheet, Dictionary<string, AnimationCycle> cycles) {
            textureAtlas = sheet;
            this.cycles = cycles;
        }

        public void SetFrameDuration(float value) {
            override_duration = value;
        }

        public void Play(string animationName) {
            if (!cycles.ContainsKey(animationName)) Debug.Warning($"Could not find animation ({animationName}).");
            else {
                _currentCycle = cycles[animationName];
            }
        }

        public void Update(GameTime gameTime) {
            float duration = override_duration > 0 ? override_duration : _currentCycle.frameDuration;

            frameIndex = 1/(duration*10) + frameIndex;
            if (frameIndex >= _currentCycle.frames.Count) {
                frameIndex = 0;
            }
            int intIndex = (int)frameIndex;
            intIndex = intIndex < _currentCycle.frames.Count ? intIndex : intIndex % _currentCycle.frames.Count;
            _currentTexture = _sheet.GetSprite(_currentCycle.frames[intIndex]);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) {
            currentTexture.Draw(spriteBatch, position);
        }

    }
}
