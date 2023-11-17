using UnityEngine;

namespace Plants
{
    public class PlantOneBullet : MonoBehaviour
    {
        [SerializeField] private Bullet.Bullet bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField, Range(0, 10)] private float reloadTime;

        private float _currentReloadTime;

        public void Shoot()
        {
            if (!(_currentReloadTime < 0)) return;
            
            Instantiate(bulletPrefab,bulletSpawnPoint.position,Quaternion.identity);
            _currentReloadTime = reloadTime;
        }

        private void Update()
        {
            if (_currentReloadTime < 0) return;

            _currentReloadTime -= Time.deltaTime;
        }
    }
}