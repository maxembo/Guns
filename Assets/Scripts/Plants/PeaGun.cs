using System.Collections;
using UnityEngine;

namespace Plants
{
    public class PeaGun : Plant
    {
        [SerializeField] private Transform bulletSpawnPoint;

        private const int MaxCountBullet = 4;
        private float _currentReloadTime;

        private void Update()
        {
            if (_currentReloadTime < 0) return;

            _currentReloadTime -= Time.deltaTime;
        }

        public override void Shoot()
        {
            if (!(_currentReloadTime < 0)) return;

            StartCoroutine(SpawnBullet());
            _currentReloadTime = reloadTime;
        }

        private IEnumerator SpawnBullet()
        {
            for (int currentBullet = 0; currentBullet < MaxCountBullet; currentBullet++)
            {
                Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}