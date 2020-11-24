using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;
    protected float lastFireTime;

    // Controls zoom when right mouse is held/pressed
    public float zoomFactor;
    public int range;
    public int damage;
    // Field of view when zoomed / ADS
    private float zoomFOV;
    private float zoomSpeed = 6;
    // Start is called before the first frame update
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
        //sets last fire time to 10 sec ago
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Right Click (Zoom)
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,
           zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            Camera.main.fieldOfView = Constants.CameraDefaultZoom;
        }
    }
    protected void Fire()
    {
        // If there is ammo, play shooting sound
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);

            //Send out a ray from gun, process hit on collision
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                processHit(hit.collider.gameObject);
            }
        }
        else // else play dry fire sound
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }
        GetComponentInChildren<Animator>().Play("Fire");

        
    }
    
    private void processHit(GameObject hitObject)
    {
        if (hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if (hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }
}

