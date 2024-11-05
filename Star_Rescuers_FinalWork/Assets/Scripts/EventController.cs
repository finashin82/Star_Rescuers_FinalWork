using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventController
{
    public static Action<float, float> onEnergy;

    public static Action<float> onAmmo;

    public static Action<int> onScore;
}
