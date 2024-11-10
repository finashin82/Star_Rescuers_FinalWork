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
        // �������� ��� ������� � ����� Sound
        gameObjects = GameObject.FindGameObjectsWithTag("Sound");

        countObjects = gameObjects.Length;
    }

    void Update()
    {
        // ���� �������� � ������� ����������� ������ ���������
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
