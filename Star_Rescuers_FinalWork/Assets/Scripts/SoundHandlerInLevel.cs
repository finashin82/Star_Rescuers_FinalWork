using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundHandlerInLevel : MonoBehaviour
{
    private GameObject[] gameObjects;

    private AudioSource audioSource;

    private int countObjects, currentCountObject = 0;

    void Start()
    {
        // Собираем все объекты с тэгом Sound
        gameObjects = GameObject.FindGameObjectsWithTag("Sound");

        countObjects = gameObjects.Length;
    }

    void Update()
    {
        // Всем объектам в массиве присваиваем нужную громкость
        if (currentCountObject < countObjects)
        {
            audioSource = gameObjects[currentCountObject].GetComponent<AudioSource>();

            audioSource.volume = SoundHandler.soundVolume;

            currentCountObject++;
        }
        else
        {
            currentCountObject = 0;
        }
    }
}
