using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseBtn;
    
    public GameObject pauseMenuUI,resetLvl;
    
    public GameObject resumeMenuUI,exitBtn,goToLevelBtn;
   
    private bool isPaused = false;
    public PipeScript pipeScript;

    
    void Start()
    {
        pauseBtn.SetActive(true);
        pauseMenuUI.SetActive(false);
         resumeMenuUI.SetActive(false);
         exitBtn.SetActive(false);
         goToLevelBtn.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseBtn.SetActive(false);
        resetLvl.SetActive(false);
        
       pauseMenuUI.SetActive(true);
         resumeMenuUI.SetActive(true);
         exitBtn.SetActive(true);
         goToLevelBtn.SetActive(true);
      
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseBtn.SetActive(true);
        resetLvl.SetActive(true);
         pauseMenuUI.SetActive(false);
        resumeMenuUI.SetActive(false);
        exitBtn.SetActive(false);
         goToLevelBtn.SetActive(false);
        
        isPaused = false;
        Time.timeScale = 1f;
    }

     public void ResetLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
