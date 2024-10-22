using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToFly : MonoBehaviour
{
    //[SerializeField] float addTime;

    [SerializeField] float _maxTimeToFly;

    private float currentTimeToFly = 2;

    public float CurrentTimeToFly { get { return currentTimeToFly; } set { currentTimeToFly = value; } }

    private void Awake()
    {
        //currentTimeToFly = _maxTimeToFly;
    }

    public void AddTimeToFly(float time)
    {
        
        currentTimeToFly += time;
    }
}
