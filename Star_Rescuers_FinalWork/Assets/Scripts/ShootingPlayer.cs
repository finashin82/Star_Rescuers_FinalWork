using UnityEngine;

public class ShootingPlayer : Shooting
{
    [SerializeField] private float maxAmmo;

    private float currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmo;

        EventController.onAmmo?.Invoke(currentAmmo);
    }

    private void Update()
    {    
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                StartFireFlash();

                Shot();

                currentAmmo -= 1;

                EventController.onAmmo?.Invoke(currentAmmo);
            }
            else
            {
                Invoke("RechargeAmmo", 1f);
            }            
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopFireFlash();
        }       
    }

    private void RechargeAmmo()
    {
        currentAmmo = maxAmmo;

        EventController.onAmmo?.Invoke(currentAmmo);
    }



}
