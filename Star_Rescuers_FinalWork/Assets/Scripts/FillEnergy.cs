using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillEnergy : MonoBehaviour
{
    [SerializeField] private Image _energyCount;

    [SerializeField] private Text _countEnergyText;

    public void FillEnergyCount(FlyPlayer flyPlayer)
    {
        _energyCount.fillAmount = flyPlayer.CurrentTimeToFly / flyPlayer.MaxTimeToFly;

        _countEnergyText.text = flyPlayer.MaxTimeToFly.ToString();
    }
}
