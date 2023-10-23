using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int MAX_SCORE = 3000;

    public GameObject winScreen;
    public TMP_Text scoreText;
    
    public ScoreManager instance;
    private void Start() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void IncreaseScore(int n)
    {
        score +=n;
        scoreText.text = score.ToString();
        if (score >= MAX_SCORE)
        {
            //WIN GAME
            Time.timeScale=0;
            
            winScreen.SetActive(true);
        }
    }
    public void StartOver()
    {
        Time.timeScale =1;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); //might need to change this
    }
    public void MainMenu()
    {
         Time.timeScale =1;
        SceneManager.LoadScene("MainMenu"); //might need to change this
    }
}
