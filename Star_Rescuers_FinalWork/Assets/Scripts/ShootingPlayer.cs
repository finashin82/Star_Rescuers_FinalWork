using UnityEngine;

public class ShootingPlayer : Shooting
{
    [SerializeField] private float maxAmmo;

    [SerializeField] private float timeRecharge;

    private SoundInTheGame soundInTheGame;

    private float currentAmmo;

    private bool isShot;

    private void Start()
    {
        currentAmmo = maxAmmo;

        soundInTheGame = GetComponent<SoundInTheGame>();

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

                soundInTheGame.SoundToShootingPlayer();

                currentAmmo -= 1;

                EventController.onAmmo?.Invoke(currentAmmo);
            }
            else
            {
                soundInTheGame.SoundEmptyAmmo();

                Invoke("RechargeAmmo", timeRecharge);                
            }            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            soundInTheGame.SoundEmptyAmmo();

            RechargeAmmo();
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
