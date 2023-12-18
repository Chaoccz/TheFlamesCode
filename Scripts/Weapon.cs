using UnityEngine;

namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public GameObject projectile;
        public Transform shotPoint;
        public float timeBetweenShots;

        private float shotTime;
        private Animator cameraAnim;

        public void Start()
        {
            cameraAnim = Camera.main.GetComponent<Animator>();
        }
        // Update is called once per frame
        private void Update()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time >= shotTime)
                {
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    cameraAnim.SetTrigger("shake");
                    shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }
}
