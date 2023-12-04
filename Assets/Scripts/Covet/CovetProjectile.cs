using UnityEngine;

namespace OpenSystemGames.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CovetProjectile : MonoBehaviour
    {
        public float projectileSpeed;
        public new Rigidbody2D rigidbody2D;
        public float projectileLifetime;

        private float timer;
        private void Start()
        {
            rigidbody2D.velocity = transform.up * projectileSpeed;
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (projectileLifetime < timer)
            {
                Destroy(gameObject);
            }

        }
    }
}
