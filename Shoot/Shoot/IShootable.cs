using Microsoft.Xna.Framework;

namespace Shoot
{
    public interface IShootable
    {
        Rectangle Hitbox { get; set; }
        void TakeDamage(int Damage);
    }
}