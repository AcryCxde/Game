using Microsoft.Xna.Framework;

namespace GameFrst
{
    public interface ICanCollide
    {
        void UpdateFlagFloor(bool up, bool down, bool right, bool left);
        void UpdateFlagDoor(bool up, bool down);

        Rectangle Rectangle { get; }
    }
}
