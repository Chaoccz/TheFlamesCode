using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneTransitions : MonoBehaviour
    {
        private Animator transitionAnim;
        // Start is called before the first frame update
        private void Start()
        {
            transitionAnim = GetComponent<Animator>();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(Transition(sceneName));
        }

        IEnumerator Transition(string sceneName)
        {
            transitionAnim.SetTrigger("end");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
        }

    }
}
