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
    
    //Check is missle has collided with player
    //Missile destroys itself and does damage
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null
        && collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
