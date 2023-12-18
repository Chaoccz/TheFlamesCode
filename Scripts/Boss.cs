using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Boss : MonoBehaviour
    {
        public int health;
        public Enemy[] enemies;
        public float spawnOffset;

        private int halfHealth;
        private Animator anim;
        public int damage;
        public GameObject deathEffect;
        public GameObject blood;
        private Slider healthBar;
        private SceneTransitions sceneTransitions;

        // Start is called before the first frame update
        private void Start()
        {
            halfHealth = health / 2;
            anim = GetComponent<Animator>();
            healthBar = FindObjectOfType<Slider>();
            healthBar.maxValue = health;
            healthBar.value = health;
            sceneTransitions = FindObjectOfType<SceneTransitions>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Player>().TakeDamage(damage);
            }
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            healthBar.value = health;
            if (health <= 0)
            {
                var instantiatedBlood = Instantiate(blood, transform.position, Quaternion.identity);
                Destroy(instantiatedBlood, 3);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                healthBar.gameObject.SetActive(false);
                sceneTransitions.LoadScene("Win");
            }

            if (health <= halfHealth)
            {
                anim.SetTrigger("stage2");
            }

            Enemy randEnemy = enemies[Random.Range(0, enemies.Length)];
            Instantiate(randEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
        }
    }
}
