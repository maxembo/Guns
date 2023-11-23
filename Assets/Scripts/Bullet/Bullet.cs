using System;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField,Range(0,10)] private float speed = 2;

        private void Start() => Destroy(gameObject, 5f);

        private void Update() => transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
