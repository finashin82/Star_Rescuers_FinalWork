using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAmmo : MonoBehaviour
{
    [SerializeField] private Text _currentAmmo;

    private void OnEnable()
    {
        EventController.onAmmo += FillCurrentAmmo;
    }

    private void OnDisable()
    {
        EventController.onAmmo -= FillCurrentAmmo;
    }

    private void FillCurrentAmmo(float currentAmmo)
    {
        _currentAmmo.text = currentAmmo.ToString();
    }
}
