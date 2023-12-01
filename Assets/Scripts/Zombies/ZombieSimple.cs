using UnityEngine;

namespace Zombies
{ 
    public class ZombieSimple : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed;
    
        private void Update()
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }
    }
}
