using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public float speed;

        public float lifeTime;

        public GameObject explosion;

        public int damage;

        public GameObject soundObject;

        // Start is called before the first frame update
        private void Start()
        {
            Invoke("DestroyProjectile", lifeTime);
            Instantiate(soundObject, transform.position, transform.rotation);
        }

        // Update is called once per frame
        private void Update()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        private void DestroyProjectile()
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<Enemy>().TakeDamage(damage);
                DestroyProjectile();
            }

            if (collision.tag == "Boss")
            {
                collision.GetComponent<Boss>().TakeDamage(damage);
                DestroyProjectile();
            }
        }
    }
}
