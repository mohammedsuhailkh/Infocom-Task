using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // Start is called before the first frame update
  float[] rotations = {0,90,180,270};
  public float[] correctrotation;
  int PossibleRotations =1;
  [SerializeField]bool isPlaced = false;
  GameManager gameManager; 

  private void Awake() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

 void Start()
{
    Time.timeScale = 1f;
    PossibleRotations = correctrotation.Length;
    int rand = Random.Range(0, rotations.Length);
    transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

    if (PossibleRotations > 1)
    {
        foreach (var correct in correctrotation)
        {
            if (Mathf.Round(transform.eulerAngles.z) == correct)
            {
                isPlaced = true;
                gameManager.CorrectMove();
                break;
            }
        }
    }
    else
    {
        if (Mathf.Round(transform.eulerAngles.z) == correctrotation[0])
        {
            isPlaced = true;
            gameManager.CorrectMove();
        }
    }
}


private void OnMouseDown() {
    transform.Rotate(new Vector3(0, 0, 90));

    bool isCorrectRotation = false;
    foreach (var rotation in correctrotation) {
        if (Mathf.Approximately(transform.eulerAngles.z, rotation)) {
            isCorrectRotation = true;
            break;
        }
    }

    if (isCorrectRotation && !isPlaced) {
        isPlaced = true;
        gameManager.CorrectMove();
    } else if (isPlaced) {
        isPlaced = false;
        gameManager.wrongMove();
    }
}

}
