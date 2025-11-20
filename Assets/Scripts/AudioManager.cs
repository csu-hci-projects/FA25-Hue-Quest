
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    public AudioClip planet;
    public AudioClip jump;
    public AudioClip select;
    public AudioClip death;

    private void Start() {
        musicSource.clip = planet;
        musicSource.time = 20;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
