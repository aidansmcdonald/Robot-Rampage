using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 10;
    [SerializeField]
    private int assaultRifleAmmo = 50;
    // Allows mapping a gun type to ammunition count
    public Dictionary<string, int> tagToAmmo;
    
    // Runs before start to prevent null access errors
    void Awake()
    {
       tagToAmmo = new Dictionary<string, int>
       {
           //makes each gun type a key in the dictionary, sets key value to ammo
          { Constants.Pistol , pistolAmmo },
          { Constants.Shotgun , shotgunAmmo },
          { Constants.AssaultRifle , assaultRifleAmmo },
       };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Adds ammunition to appropriate gun type
    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        tagToAmmo[tag] += ammo;
    }

    // Returns true if gun has ammo, false if empty
    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed: " + tag);
        }
        return tagToAmmo[tag] > 0;
    }

    // Returns bullet count for gun type
    public int GetAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        return tagToAmmo[tag];
    }

    // Consumes Ammo
    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag))
        {
            Debug.LogError("Unrecognized gun type passed:" + tag);
        }
        tagToAmmo[tag]--; //subtract a bullet from specific gun
        gameUI.SetAmmoText(tagToAmmo[tag]);
    }
}
