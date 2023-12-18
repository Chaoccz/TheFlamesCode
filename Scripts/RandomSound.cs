using UnityEngine;

namespace Assets.Scripts
{
    public class RandomSound : MonoBehaviour
    {
        private AudioSource source;

        public AudioClip[] clips;
        // Start is called before the first frame update
        void Start()
        {
            source = GetComponent<AudioSource>();
            int randomNumber = Random.Range(0, clips.Length);
            source.clip = clips[randomNumber];
            source.Play();
        }


    }
}
