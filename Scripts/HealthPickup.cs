using UnityEngine;

namespace Assets.Scripts
{
    public class HealthPickup : MonoBehaviour
    {

        private Player playerScript;
        public int healAmount;
        public GameObject effect;

        private void Start()
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                playerScript.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
