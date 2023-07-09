using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioSource audioSource;

    public static SoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if(instance == null)
                {
                    GameObject soundManager = new GameObject("SoundManager");
                    instance = soundManager.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    public AudioClip obstacleSound;
    public AudioClip scoringSound;
    public AudioClip jumpSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
