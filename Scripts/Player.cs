using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public float speed;
        private Rigidbody2D rb;
        private Animator anim;
        private Vector2 moveAmount;
        public int health;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyheart;
        public Animator hurtAnim;
        private SceneTransitions sceneTransitions;

        private void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            sceneTransitions = FindObjectOfType<SceneTransitions>();
        }

        private void Update()
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveAmount = moveInput.normalized * speed;

            anim.SetBool("isRunning", moveInput != Vector2.zero);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
        }

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            UpdateHealthUI(health);
            hurtAnim.SetTrigger("hurt");
            if (health <= 0)
            {
                Destroy(gameObject);
                sceneTransitions.LoadScene("Lost");
            }
        }

        public void ChangeWeapon(Weapon weaponToEquip)
        {
            Destroy(GameObject.FindGameObjectWithTag("Weapon"));
            var weaponscale = Instantiate(weaponToEquip, transform.position, transform.rotation, transform);
            weaponscale.transform.localScale = new Vector2(1, 1);
        }

        private void UpdateHealthUI(int currentHealth)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = i < currentHealth ? fullHeart : emptyheart;
            }
        }

        public void Heal(int healAmount)
        {
            if (health + healAmount > 5)
            {
                health = 5;
            }
            else
            {
                health += healAmount;
            }
            UpdateHealthUI(health);

        }
    }
}
