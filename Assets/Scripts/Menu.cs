using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Loads battle scene when begin button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }
    // Exits the app (Will not exit unity)
    public void Quit()
    {
        Application.Quit();
    }

// Update is called once per frame
void Update()
    {
        
    }
}
