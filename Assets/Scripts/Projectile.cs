using UnityEngine;

namespace OpenSystemGames.Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        public float rotationOffset = -90;
        public float projectileSpeed;
        public new Rigidbody2D rigidbody2D;
        public float projectileLifetime;

        private float timer ;
        void Start()
        {
            Vector3 target = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            target.z = 0;

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg + rotationOffset;
            transform.Rotate(0, 0, angle);
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
