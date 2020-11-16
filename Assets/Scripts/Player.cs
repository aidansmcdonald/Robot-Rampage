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
         return;
         }
            armor = 0;
         }

         health -= healthDamage;
         Debug.Log("Health is " + health);

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
    }
    // Adds players armour
    private void pickupArmor()
    {
        armor += 15;
    }
    // Adds ammunition for specific gun types
    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }
    private void pickupPisolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
    }
    private void pickupShotgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 10);
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
