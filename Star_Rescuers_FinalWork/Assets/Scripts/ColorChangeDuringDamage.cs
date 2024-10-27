using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeDuringDamage : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeNewColor()
    {
        sr.color = Color.red;

        Invoke("BackOriginalColor", 0.1f);
    }

    private void BackOriginalColor()
    {
        sr.color = Color.white;
    }
}
