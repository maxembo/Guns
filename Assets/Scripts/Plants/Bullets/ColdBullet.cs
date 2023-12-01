using Zombies;
using UnityEngine;

namespace Plants.Bullets
{
    public class ColdBullet : Bullet
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            foreach (var hit in DamageHit)
            {
                if (hit.TryGetComponent(out ZombieSimple zombie))
                {
                    zombie.StartWork();
                }
            }
        }
    }
}