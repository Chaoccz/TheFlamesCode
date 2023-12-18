using UnityEngine;

namespace Assets.Scripts
{
    public class BossSounds : MonoBehaviour
    {
        private AudioSource source;

        public AudioClip[] clips;

        public float timeBetweenSoundEffects;

        private float nextSoundEffectTime;
        // Start is called before the first frame update

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Time.time >= nextSoundEffectTime)
            {
                int randomNumber = Random.Range(0, clips.Length);
                source.clip = clips[randomNumber];
                source.Play();
                nextSoundEffectTime = Time.time + timeBetweenSoundEffects;
            }

        }
    }
}
