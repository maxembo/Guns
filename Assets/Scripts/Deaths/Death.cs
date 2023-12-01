using Deaths;
using UnityEngine;

namespace Deaths
{
    public class Death : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        private const int HealthAtDeath = 0;
        private int _currentHealth;

        private void Start() => _currentHealth = maxHealth;

        public int ShowHealth()
        {
            return _currentHealth;
        }
        public void ApplyDamage(int damageValue)
        {
            _currentHealth -= damageValue;

            HealthForDestroy();
        }

        private void HealthForDestroy()
        {
            if (_currentHealth > HealthAtDeath) return;
            Destroy(gameObject);
        }
    }
}