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

        EventController.onMaxEnegry += FillMaxEnergy;

    }

    private void OnDisable()
    {
        EventController.onEnergy -= FillEnergyCount;       

        EventController.onMaxEnegry -= FillMaxEnergy;
    }

    public void FillEnergyCount(float currentTimeToFly, float maxTimeToFly)
    {
        _energyCount.fillAmount = currentTimeToFly / maxTimeToFly;        
    }

    public void FillMaxEnergy(float maxTimeToFly)
    {
        _countEnergyText.text = maxTimeToFly.ToString();
    }
}
