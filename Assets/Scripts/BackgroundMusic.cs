using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Start()
    {
        // Ensures game object is not deleted when changing scenes
        DontDestroyOnLoad(gameObject);
    }
}
