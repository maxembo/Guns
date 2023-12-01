using System.Collections;
using UnityEngine;

namespace Zombies
{
    public class ZombieSimple : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed;
        [SerializeField] private float minSlowdown = 1f;
        [SerializeField] private float timeSlowdown = 2f;

        private MeshRenderer _meshRenderer;
        private Coroutine _slowdown;
        private float _initialSpeed;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _initialSpeed = speed;
        }

        private void Update()
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }

        public void StartWork()
        {
            if (_slowdown != null)
            {
                StopCoroutine(_slowdown);
            }

            _slowdown = StartCoroutine(SlowDown());
        }

        private IEnumerator SlowDown()
        {
            speed = minSlowdown;
            _meshRenderer.material.color = Color.blue;

            yield return new WaitForSeconds(timeSlowdown);

            _meshRenderer.material.color = Color.white;
            speed = _initialSpeed;
        }
    }
}
