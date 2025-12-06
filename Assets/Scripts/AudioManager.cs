
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    
    public AudioClip jump;
    public AudioClip select;
    public AudioClip walk;
    public AudioClip death;
    public AudioClip BGM;

    void Start()
    {
        musicSource.volume = 0.5f;
        SFXSource.volume = 0.3f;
        PlaySong(BGM, 0);
    }

    void Update()
    {
        toggleMenu(false);
    }

    public void toggleMenu(bool toggle)
    {
        if (Input.GetKeyDown(KeyCode.Escape) || toggle)
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
            }
            else
            {
                settingsMenu.SetActive(true);
            }
        }
    }

    public void PlaySong(AudioClip song, int statTime)
    {
        if (song != null)
        {
            musicSource.clip = song;
            musicSource.time = statTime;
            musicSource.Play();
        }
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
    
    public void Playdeath()
    {
        SFXSource.PlayOneShot(death);
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    public void changeSFXVolume()
    {
        SFXSource.volume = SFXSlider.value;
    }

    public void changeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
    }
}
