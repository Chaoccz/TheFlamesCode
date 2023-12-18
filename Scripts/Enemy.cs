using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public int health;

        [HideInInspector]
        public Transform player;

        public float speed;

        public float timeBetweenAttacks;

        public int damage;

        public int pickupChance;

        public GameObject[] pickups;

        public int healthPickupChance;

        public GameObject healthPickup;

        public GameObject deathEffect;
        // Start is called before the first frame update
        public virtual void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;

            if (health <= 0)
            {
                int randomNumber = Random.Range(0, 101);
                if (randomNumber < pickupChance)
                {
                    GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                    Instantiate(randomPickup, transform.position, transform.rotation);
                }

                int randHealth = Random.Range(0, 101);
                if (randHealth <= healthPickupChance)
                {
                    Instantiate(healthPickup, transform.position, transform.rotation);
                }

                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
