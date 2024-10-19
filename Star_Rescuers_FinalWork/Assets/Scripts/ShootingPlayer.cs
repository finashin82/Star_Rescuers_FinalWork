using UnityEngine;

public class ShootingPlayer : Shooting
{
    private void Update()
    {    
        if (Input.GetMouseButtonDown(0))
        {
            StartFireFlash();

            Shot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopFireFlash();
        }       
    }

   
}
