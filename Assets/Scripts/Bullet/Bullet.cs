using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2f;
        [SerializeField] private float radius;
        private int _damage = 1;

        private void Start() => Destroy(gameObject, 8f);

        private void Update() => transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        private void OnTriggerEnter(Collider other)
        {
            var damage = Physics.OverlapSphere(transform.position, radius);
            
            foreach (var hit in damage)
            {
                if (hit.TryGetComponent(out Death death))
                {
                    death.ApplyDamage(_damage);
                    Destroy(gameObject);
                    Debug.Log(death.ShowHealth());
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