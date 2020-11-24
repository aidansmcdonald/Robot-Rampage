using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyAutoShotgun : Gun
{
    override protected void Update()
    {
        base.Update();
        // Automatic Fire
        //GetMouseButton checks for held left mouse button instead of click
        if (Input.GetMouseButton(0) && Time.time - lastFireTime > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
