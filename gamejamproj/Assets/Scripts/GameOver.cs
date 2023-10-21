using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartOver()
    {
        SceneManager.LoadScene("TestScene"); //might need to change this
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //might need to change this
    }
}
