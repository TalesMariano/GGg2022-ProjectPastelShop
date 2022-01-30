using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool autoStart = false;
    public bool loopMusic = true;
    public bool startRandomMusic = false;
    public bool startRandomPoint = false;

    [Space]

    private AudioSource audioSource;

    public MusicList musicList;

    //Singleton
    public static AudioManager I = null;
    void Awake()
    {
        if (I == null)           //Check if instance already exists
            I = this;            //if not, set instance to this
        else if (I != this)
        {      //If instance already exists and it's not this:
            //instance.LoadNext();
            Destroy(gameObject);        //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
        DontDestroyOnLoad(gameObject);  //Sets this to not be destroyed when reloading scene

        //--------------------

        audioSource = GetComponent<AudioSource>();
        SetMusic();
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        audioSource.loop = loopMusic;

        if (autoStart)
            PlayNextSong();
    }

    // Not optime or bug free T-T
    void SetMusic()
    {
        audioSource.clip = musicList.musicClips[0];
    }

    void PlayNextSong()
    {
        audioSource.clip = musicList.musicClips[Random.Range(0, musicList.musicClips.Length)];
        audioSource.Play();
        Invoke("PlayNextSong", audioSource.clip.length);
    }
}
