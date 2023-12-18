using UnityEngine;

namespace Assets.Scripts
{
    public class Pickup : MonoBehaviour
    {

        public Weapon weaponToEquip;

        public GameObject effect;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
                Destroy(gameObject);
            }
        }
    }
}
