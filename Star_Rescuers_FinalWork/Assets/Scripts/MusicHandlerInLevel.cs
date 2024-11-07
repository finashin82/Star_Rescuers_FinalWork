using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandlerInLevel : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
       
    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = MusicHandler.musicVolume;
    }
}
