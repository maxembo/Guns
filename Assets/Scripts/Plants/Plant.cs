using Plants.Bullets;
using UnityEngine;

namespace Plants
{
    public abstract class Plant : MonoBehaviour
    {
        [SerializeField] protected Bullet bulletPrefab;
        [SerializeField,Range(0,10)] protected float reloadTime;
        
        public abstract void Shoot();
    }
}