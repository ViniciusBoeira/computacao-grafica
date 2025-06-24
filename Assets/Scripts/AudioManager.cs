using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] soundEffects;

    public static AudioManager instance;

    private void Awake() {
        instance = this;
    } 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay) {
        soundEffects[soundToPlay].Play();
    }
}
