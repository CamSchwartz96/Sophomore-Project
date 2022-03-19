using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int startBallAmount = 3;
    int currentBallAmount;

    public GameObject ballPrefab;
    public Transform spawnPoint;
    
    bool gameStarted;
    void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        currentBallAmount = startBallAmount;
        CreateNewBall();
    }

    public void CreateNewBall()
    {
        Instantiate(ballPrefab,spawnPoint.position, Quaternion.identity);
        currentBallAmount--;
    }


}
