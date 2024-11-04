using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInTheGame : MonoBehaviour
{
    [SerializeField] private AudioSource _soundToFly;

    [SerializeField] private AudioSource _soundToShooting;

    [SerializeField] private AudioSource _soundToRunPlayer;

    [SerializeField] private AudioSource _soundTakeBonus;

    [SerializeField] private AudioSource _soundEmptyAmmo;

    [SerializeField] private AudioSource _soundJumpPlayer;

    public void FlameToFlySoundPlay()
    {
        _soundToFly.Play();
    }
    
    public void FlameToFlySoundStop()
    {
        _soundToFly.Stop();
    }

    public void SoundToShootingPlayer()
    {
        _soundToShooting.Play();
    }

    public void SoundToRunPlayer()
    {
        _soundToRunPlayer.Play();
    }

    public void SoundTakeBonus() 
    { 
        _soundTakeBonus.Play(); 
    }
    
    public void SoundEmptyAmmo() 
    { 
        _soundEmptyAmmo.Play(); 
    }
    
    public void SoundJumpPlayer() 
    { 
        _soundJumpPlayer.Play(); 
    }
}
