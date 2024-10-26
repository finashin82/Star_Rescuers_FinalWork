using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillEnergy : MonoBehaviour
{
    [SerializeField] private Image _energyCount;

    [SerializeField] private Text _countEnergyText;

    private void OnEnable()
    {
        EventController.onEnergy += FillEnergyCount;
    }

    private void OnDisable()
    {
        EventController.onEnergy -= FillEnergyCount;
    }

    public void FillEnergyCount(float currentTimeToFly, float maxTimeToFly)
    {
        _energyCount.fillAmount = currentTimeToFly / maxTimeToFly;

        _countEnergyText.text = maxTimeToFly.ToString();
    }
}
