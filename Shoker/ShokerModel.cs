using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using GameFrst.InputClass;
using GameFrst.Anotogonist;

namespace GameFrst.Shoker
{
    public class ShokerModel
    {
        public Texture2D currentTex;
        public Vector2 currentShift;

        public Vector2 LShift = new Vector2(-89, 100);
        public Vector2 DShift = new Vector2(33, 167);
        public Vector2 RShift = new Vector2(89, 89);
        public Vector2 UShift = new Vector2(67, -89);

        public Dictionary<string, Texture2D> shokerDict;

        public static bool isFiring = false;
        public static float lastShotTime = -10f;
        public static float firingStartTime = 0f;

        public static Rectangle rectangle;

        public Vector2 shokerPos;

        public static Input input;

        public ShokerController controller;
        public ShokerView view;

        public ShokerModel(Dictionary<string, Texture2D> shokerDict)
        {
            this.shokerDict = shokerDict;
            input = new Input();

            controller = new ShokerController(this);
            view = new ShokerView(this);
        }
    }
}
