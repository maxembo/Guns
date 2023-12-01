using UnityEngine;

namespace Plants
{
    public class Pea : Plant
    {
        [SerializeField] private Transform bulletSpawnPoint;
        
        private float _currentReloadTime;

        private void Update()
        {
            if (_currentReloadTime < 0) return;

            _currentReloadTime -= Time.deltaTime;
        }

        public override void Shoot()
        {
            if (!(_currentReloadTime < 0)) return;
        
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            _currentReloadTime = reloadTime;
        }
    }
}