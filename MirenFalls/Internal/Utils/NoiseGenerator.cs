using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Utils {

    // Noise generator which extends the noise functions and implements some control variables that are initialized at class creation
    // important part of seeding as the actual "random" aspect of the maps comes here

    public static class NoiseGenerator {
        public class Noise {
            protected float scale;
            protected int octaves;
            protected float persistence;
            protected float lacunarity;

            protected float predictedMinHeight;
            protected float predictedMaxHeight;

            protected string seed;
            protected Vector2[] octaveOffsets;

            public Noise(float scale, int octaves, float persistence, float lacunarity, string seed = null) {
                this.scale = scale;
                this.octaves = octaves >= 1 ? octaves : 1; // Makes sure there is at least one octave
                this.persistence = persistence;
                this.lacunarity = lacunarity;
                this.seed = seed != null ? seed : System.DateTime.Now.ToString();
                this.octaveOffsets = new Vector2[octaves];

                Random.InitState(this.seed);

                for (int i = 0; i < octaves; i++) {
                    float offsetX = Random.Range(-10000f, 10000f);
                    float offsetY = Random.Range(-10000f, 10000f);
                    octaveOffsets[i] = new Vector2(offsetX, offsetY);
                }

                // Calculates the heightest possible noise value WARNING: if the noise map is generating very flat it's probably due to this.
                float tAmp = 1;
                for (int i = 0; i < octaves; i++) {
                    predictedMaxHeight = 1.2f * octaves * tAmp;
                    tAmp *= persistence;
                }
                predictedMinHeight = predictedMaxHeight * -1;
            }

            public virtual float GetValue(float x, float y) {
                return 0.5f;
            }

            public float GetValue(int x, int y) {
                return GetValue((float)x, (float)y);
            }
        }


        public class PerlinNoise : Noise {
            public PerlinNoise(float scale, int octaves, float persistence, float lacunarity, string seed = null) : base(scale, octaves, persistence, lacunarity, seed) {
            }

            public override float GetValue(float x, float y) {
                float noiseHeight = 0;
                float amplitude = 1;
                float frequency = 1;
                for (int i = 0; i < this.octaves; i++) {
                    float moddedX = (x / scale * frequency) + (octaveOffsets[i].X / scale * frequency);
                    float moddedY = (y / scale * frequency) + (octaveOffsets[i].Y / scale * frequency);


                    float perlinValue = ImprovedNoise.Noise(moddedX, moddedY);
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                }
                // While the predictions should be the max and min height, just as a backup, if there's a value exceeding our min / max then set it as the new min / max.
                //Debug.Log(noiseHeight);
                return ExtraMath.InverseLerp(predictedMinHeight, predictedMaxHeight, noiseHeight);
            }

        }
    }
}
