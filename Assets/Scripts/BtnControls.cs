using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnControls : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField]int level;
    public void StartGame(){
        SceneManager.LoadScene("Levels");
    }

    public void goHome(){
        SceneManager.LoadScene("home");
    }

    public void LoadLevel(){
        string loadingLevel = "L" + level;
        Debug.Log(loadingLevel);
        SceneManager.LoadScene(loadingLevel);
    }
}
