using UnityEngine;

namespace Plants
{
    public class PeaThree : Plant
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField,Range(1,10)] private float bulletInterval = 3f;

        private const float FinishedTime = 0f;
        private const int MaxCountBullet = 2;

        private float _currentReloadTimer;

        private void Update()
        {
            if (_currentReloadTimer < 0) return;
            
            _currentReloadTimer -= Time.deltaTime;
        }

        public override void Shoot()
        {
            if (_currentReloadTimer > FinishedTime) return;

            for (int currentBullet = -1; currentBullet < MaxCountBullet; currentBullet++) 
            {
                var bullet = Instantiate(bulletPrefab, GetBulletPosition(currentBullet), Quaternion.identity);
            }

            _currentReloadTimer = reloadTime;
        }

        private Vector3 GetBulletPosition(int bulletIndex)
        {
            return bulletSpawnPoint.position + Vector3.right * bulletIndex * bulletInterval;
        }
    }
}
