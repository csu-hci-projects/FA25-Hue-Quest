
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    public AudioClip jump;
    public AudioClip select;
    public AudioClip walk;

    void Start()
    {
        musicSource.volume = 0.5f;
        SFXSource.volume = 0.3f;
    }

    public void PlaySong(AudioClip song, int statTime)
    {
        musicSource.clip = song;
        musicSource.time = statTime;
        musicSource.Play();
    }
    
    public void Playjump()
    {
        SFXSource.PlayOneShot(jump);
    }

    public void PlaySelect()
    {
        SFXSource.PlayOneShot(select);
    }

    public void Playwalk()
    {
        if (!SFXSource.isPlaying)
        {
          SFXSource.PlayOneShot(walk);  
        }
        
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
