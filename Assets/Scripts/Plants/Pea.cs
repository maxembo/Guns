using UnityEngine;

namespace Plants
{
    public class Pea : Plant
    {
        [SerializeField] private Transform bulletSpawnPoint;

        private const float FinishedTime = 0f; 
        private float _currentReloadTimer;


        private void Update()
        {
            if (_currentReloadTimer < FinishedTime) return;

            _currentReloadTimer -= Time.deltaTime;
        }

        public override void Shoot()
        {
            if (_currentReloadTimer > FinishedTime) return;
        
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            _currentReloadTimer = reloadTime;
        }
    }
}