using Microsoft.Xna.Framework;
using System.Collections.Generic;
using GameFrst.FloorElement;

namespace GameFrst.AreaClass
{
    public class Area
    {
        public Rectangle rect;
        public int start;
        public int end;

        public void Collide(List<FloorElementModel> _floorList, ICanCollide canCollide)
        {
            if (canCollide.Rectangle.Intersects(rect))
            {
                for (var i = start; i <= end; i++)
                {
                    _floorList[i].controller.Collide(canCollide);
                }
            }
        }
    }
}
