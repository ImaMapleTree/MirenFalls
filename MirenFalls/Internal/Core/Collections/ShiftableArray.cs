using System;

namespace MirenFalls.Internal.Core.Collections {
    public class ShiftableArray<T> {

        public int width;
        public int height = 1;
        public int size;

        private T[,] array = null;
        private T[] flat_array = null;


        public ShiftableArray(int size) {
            this.size = size;
            width = size;

            flat_array = new T[size];
        }


        public ShiftableArray(int width, int height) {
            this.width = width;
            this.height = height;
            size = width * height;

            array = new T[width, height];
        }

        public void Shift(int xShift, int yShift = 0) {
            if (xShift != 0 || yShift != 0) {
                if (flat_array != null && xShift != 0) { // MUCH FASTER THAN 2D OPERATION
                    Array.Copy(flat_array, xShift * -1, flat_array, 0, flat_array.Length - 1);
                } else if (array != null) {
                    T[,] new_array = new T[width, height];

                    for (int x = 0; x < width; x++) {
                        for (int y = 0; y < height; y++) {
                            int indexX = x + xShift * -1;
                            int indexY = y + yShift;

                            new_array[x, y] = default;

                            if (indexX >= 0 && indexX < width && indexY >= 0 && indexY < height) {
                                new_array[x, y] = array[indexX, indexY];
                            }
                        }
                    }
                    array = new_array;
                }
            }
        }

        public void VerticalShift(int amount) {
            Shift(0, amount);
        }

        public void HorizontalShift(int amount) {
            Shift(amount);
        }

        public T this[int index] {
            get => flat_array[index];
            set => flat_array[index] = value;
        }

        public T this[int x, int y] {
            get => array[x, y];
            set => array[x, y] = value;
        }
    }
}
