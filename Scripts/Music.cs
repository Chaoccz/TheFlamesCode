using UnityEngine;

namespace Assets.Scripts
{
    public class Music : MonoBehaviour
    {
        private static Music instance;
        // Start is called before the first frame update
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
