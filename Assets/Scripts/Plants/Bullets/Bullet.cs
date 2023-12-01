using Deaths;
using UnityEngine;

namespace Plants.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2f;
        [SerializeField] private float radius;

        protected Collider[] DamageHit { get; private set; }

        private int _damage = 1;

        private void Start() => Destroy(gameObject, 8f);

        private void Update() => transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        protected virtual void OnTriggerEnter(Collider other)
        {
            DamageHit = Physics.OverlapSphere(transform.position, radius);

            foreach (var hit in DamageHit)
            {
                if (hit.TryGetComponent(out Death death))
                {
                    death.ApplyDamage(_damage);
                    Destroy(gameObject);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawWireSphere(position, radius);
        }
#endif
    }
}