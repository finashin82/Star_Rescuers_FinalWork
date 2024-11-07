using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public static float soundVolume = 1;

    public void SoundVolumeGame(float volume)
    {
        soundVolume = volume;
    }
}
