using UnityEngine;

namespace Assets.Scripts
{
    public class CursorFollow : MonoBehaviour
    {
        private void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
