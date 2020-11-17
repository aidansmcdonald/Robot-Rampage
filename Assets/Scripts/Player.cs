using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    // Armor is extra health that receives 50% reduced damage
    public int armor;
    // Script references
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    // Ammo class reference
    private Ammo ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount) 
    {
         int healthDamage = amount;

         if (armor > 0)
         {
         int effectiveArmor = armor * 2;
         effectiveArmor -= healthDamage;

         // If there is still armor, don't need to process
         // health damage
         if (effectiveArmor > 0)
         {
         armor = effectiveArmor / 2;
         gameUI.SetArmorText(armor);
         return;
         }
            armor = 0;
            gameUI.SetArmorText(armor);
         }

         health -= healthDamage;
        gameUI.SetHealthText(health);

        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
    
    // Adds players health
    private void pickupHealth()
    {
        health += 50;
        if (health > 200)
        {
            health = 200;
        }
        gameUI.SetPickUpText("Health picked up + 50 Health");
        gameUI.SetHealthText(health);
    }
    // Adds players armour
    private void pickupArmor()
    {
        armor += 15;
        gameUI.SetPickUpText("Armor picked up + 15 armor");
        gameUI.SetArmorText(armor);
    }
    // Adds ammunition for specific gun types
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
        //Alerts player of ammunition pickup with ui text
        gameUI.SetPickUpText("Assault rifle ammo picked up + 50 ammo");
        //Checks if active weapon is AR before setting ammo count
        if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.AssaultRifle));
        }
    }
    private void pickupPisolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
        gameUI.SetPickUpText("Pistol ammo picked up + 20 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Pistol));
        }
    }
    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
        gameUI.SetPickUpText("Shotgun ammo picked up + 10 ammo");
        if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun)
        {
            gameUI.SetAmmoText(ammo.GetAmmo(Constants.Shotgun));
        }
    }

    // Takes an int that reps an item/pickup
    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpArmor:
                pickupArmor();
                break;
            case Constants.PickUpHealth:
                pickupHealth();
                break;
            case Constants.PickUpAssaultRifleAmmo:
                pickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                pickupPisolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:

                pickupShotgunAmmo();
                break;
            default:
                Debug.LogError("Bad pickup type passed" + pickupType);
                break;
        }
    }
}
