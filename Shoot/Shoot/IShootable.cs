using Microsoft.Xna.Framework;

namespace Shoot
{
    public enum ShootableLayer
    {
        One,
        Two,
        Three,
        Four,
        Five
    }
    public interface IShootable
    {
        ShootableLayer Layer { get; }
        Rectangle Hitbox { get; set; }
        void TakeDamage(int Damage);
    }
}