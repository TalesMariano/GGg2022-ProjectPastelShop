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

    private void Awake()
    {
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
