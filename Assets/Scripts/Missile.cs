using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    
    // Start coroutine called deathTimer on missile instantiation
    void Start()
    {
        StartCoroutine("deathTimer");
    }
    // Missile moves forward at speed
    // Multiplied by time between frames
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    // After 10s, auto destruct
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
