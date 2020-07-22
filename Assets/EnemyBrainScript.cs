using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrainScript : MonoBehaviour
{

    public EnemyBallScript enemyBallScript;

    public void ExecuteCommand()
    {
        enemyBallScript.EnemyTurn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
