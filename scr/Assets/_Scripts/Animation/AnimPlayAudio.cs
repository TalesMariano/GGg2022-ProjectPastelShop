using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayAudio()
    {
        audioSource.Play();
    }

    public void GoNextScene()
    {
        MySceneManager.I.LoadNextScene();
    }
}
