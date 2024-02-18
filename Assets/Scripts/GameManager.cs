using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PipesHolder;
    public GameObject[] pipes; 
   
     [SerializeField]int totalPipes = 0;
      [SerializeField]int  correctedPIpes = 0;
       public TextMeshProUGUI timerText;
    public float timeRemaining = 30f;
    private bool timerIsRunning = false;
    void Start()
    {
        Time.timeScale = 1f;
        timerIsRunning = true;
        totalPipes = PipesHolder.transform.childCount;
        pipes = new GameObject[totalPipes];

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    private void Update() {
        Timer();
    }

    void Timer(){
        if (timerIsRunning)
        {
            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timerIsRunning = false;
              SceneManager.LoadScene("GameOver");
            }
        }
    }
     void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{00}", seconds);
    }

    public void CorrectMove(){
        correctedPIpes += 1;
        Debug.Log("correct move");
        if(correctedPIpes == totalPipes){
            Debug.Log("you won");
             SceneManager.LoadScene("Gamewon");
        }
    }

    // Update is called once per frame
  public void wrongMove(){
    correctedPIpes -= 1;
  }
}
