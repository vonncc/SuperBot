using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public enum TurnManager
    {
        player,
        enemy
    };

    TurnManager turnManager;
    TouchManager mTouchManager;
    public static bool isPlaying;

    public GameObject gameOverPanel;
    public EnemyBrainScript enemyBrainScript;
    public UnityEngine.UI.Text userScoreText;

    float userScore;

    int turnIndicator;
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver()
    {
        isPlaying = false;
        gameOverPanel.SetActive(true);
    }

    private void Start()
    {
        mTouchManager = GameObject.FindGameObjectWithTag("TouchManager").GetComponent<TouchManager>();
        turnManager = TurnManager.player;
        isPlaying = true;
    }

    public void ChangeTurn()
    {
        //turnManager = mTurnManager;
        turnIndicator += 1;
        if (turnIndicator >= 2)
        {
            turnIndicator = 0;
        }
        switch (turnIndicator)
        {
            case 0:
                mTouchManager.canShoot = true;
                break;
            case 1:
                enemyBrainScript.ExecuteCommand();
                break;
        }
    }

    public int GetCurrentTurn()
    {
        return turnIndicator;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            userScore += Time.deltaTime;
            userScoreText.text = "SCORE\n" + (Mathf.Ceil(userScore*100)/100).ToString();
        }

        //if ()
    }
}
