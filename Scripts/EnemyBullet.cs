using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBullet : MonoBehaviour
    {

        private Player playerScript;

        private Vector2 targetPosition;

        public float speed;

        public int damage;

        public GameObject effect;
        // Start is called before the first frame update
        private void Start()
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            targetPosition = playerScript.transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            if ((Vector2)transform.position == targetPosition)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                playerScript.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
