using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    public static string activeWeaponType;
    // References to guns
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    public GameObject fullyAutoShotgun;
    // Active gun
    GameObject activeGun;

    // Reference to GameUI
    [SerializeField]
    GameUI gameUI;

    [SerializeField]
    Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        // Starting gun is pistol
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("4"))
        {
            loadWeapon(fullyAutoShotgun);
            activeWeaponType = Constants.FullyAutoShotgun;
            gameUI.UpdateReticle();
        }
    }

    //Turn off all gun objects except the one passed in
    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        fullyAutoShotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }

    // Returns active Gun for other scripts to read
    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
