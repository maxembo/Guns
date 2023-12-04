using System.Collections;
using UnityEngine;

namespace Plants
{
    public class PeaGun : Plant
    {
        [SerializeField] private Transform bulletSpawnPoint;

        private const float FinishedTime = 0f;
        private const int MaxCountBullet = 4;
        private const float FireRate = 0.2f;

        private float _currentReloadTimer;

        private void Update()
        {
            if (_currentReloadTimer < FinishedTime) return;

            _currentReloadTimer -= Time.deltaTime;
        }

        public override void Shoot()
        {
            if (_currentReloadTimer > FinishedTime) return;

            StartCoroutine(SpawnBullet());
            _currentReloadTimer = reloadTime;
        }

        private IEnumerator SpawnBullet()
        {
            for (int currentBullet = 0; currentBullet < MaxCountBullet; currentBullet++)
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(FireRate);
            }
        }
    }
}