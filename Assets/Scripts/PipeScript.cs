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
  public float gridSize = 1.0f;

  Vector3 offset;
    bool isDragging = false;
    float lastRotationTime = 0f;
    float rotationCooldown = 0.5f;
    [SerializeField]Transform correctPosition;
 
    

  private void Awake() {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

 void Start()
{
    Time.timeScale = 1f;
    transform.position = GetRandomPosition();


 
}

private void Update() {
    
            if ( transform.position == correctPosition.position)
            {
                isPlaced = true;
                gameManager.CorrectMove();
                
            }
  
    else
    {
        if ( transform.position == correctPosition.position)
        {
            isPlaced = true;
            gameManager.CorrectMove();
        }
    }
}

 Vector3 GetRandomPosition()
    {
        // Calculate random position based on gridSize
        Vector3 randomPos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        randomPos.x = Mathf.Round(randomPos.x / gridSize) * gridSize;
        randomPos.y = Mathf.Round(randomPos.y / gridSize) * gridSize;
        return randomPos;
    }


private void OnMouseDown() {

    if (!isDragging)
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


   


    if (isPlaced) {
        isPlaced = true;
        gameManager.CorrectMove();
    } else if (!isPlaced) {
        isPlaced = false;
        gameManager.wrongMove();
    }
}



void OnMouseDrag()
{
    isDragging = true;

    // Calculate the offset from the initial mouse position
    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

    // Calculate the snapped position based on the initial position and grid size
    curPosition.x = Mathf.Round((curPosition.x - transform.position.x) / gridSize) * gridSize + transform.position.x;
    curPosition.y = Mathf.Round((curPosition.y - transform.position.y) / gridSize) * gridSize + transform.position.y;

    transform.position = curPosition;
}


    void OnMouseUp()
    {
        isDragging = false;

        Vector3 endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = endPosition - transform.position;

    }



}



