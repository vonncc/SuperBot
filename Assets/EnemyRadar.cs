using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    public Transform parentTransform;
    public EnemyScript enemyScript;
    Transform homingTransform;
    bool foundSomething;

    float counterToShoot;

    public delegate void Express();

    public bool constantLooking;

    //Express express;

    void DoFunction(string pTag, Express pExpress)
    {
        if (pTag == "Player")
        {
            if (constantLooking == false)
                pExpress();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Express newExpression = () => {
            foundSomething = true;
            homingTransform = other.transform;
            parentTransform.LookAt(other.transform.position, Vector3.up);
            enemyScript.StartShoot();
        };
        DoFunction(other.tag, newExpression);

    }

    private void OnTriggerStay(Collider other)
    {
        Express newExpression = () => {
            parentTransform.LookAt(new Vector3(homingTransform.position.x, 0, homingTransform.position.z), Vector3.up);
        };
        DoFunction(other.tag, newExpression);
    }

    private void OnTriggerExit(Collider other)
    {
        Express newExpression = () => {
            foundSomething = false;
            homingTransform = null;
            enemyScript.StopShoot();
        };
        DoFunction(other.tag, newExpression);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (constantLooking == true)
        {
            enemyScript.StartShoot();
            homingTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        //if (foundSomething == true)
        //{
        //    counterToShoot += Time.deltaTime;

        //    //if ()
        //    //parentTransform.LookAt(homingTransform, Vector3.up);
        //}
        if (constantLooking == true && homingTransform != null)
            parentTransform.LookAt(new Vector3(homingTransform.position.x, 0, homingTransform.position.z), Vector3.up);
    }
}
