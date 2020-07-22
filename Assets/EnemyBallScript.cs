using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallScript : MonoBehaviour
{
    PlayerMovement mPlayerMovement;
    Transform playerTransform;

    bool imaginaryAiming;
    float aimingCounter;
    void EnemyAim()
    {
        int accuracyRandom = Random.Range(0, 11);

        float tenTX;
        float tenTY;
        accuracyRandom = 2;
        if (accuracyRandom <= 1)
        {
            tenTX = playerTransform.position.x - transform.position.x;
            tenTY = playerTransform.position.z - transform.position.z;
        } else
        {
            tenTX = (playerTransform.position.x + Random.Range(-5, 5)) - transform.position.x;
            tenTY = (playerTransform.position.z + Random.Range(-5, 5)) - transform.position.z;
        }
        

        //                    local t1 = math.cos(math.atan2(TenTY, tenTX))

        //                    local t2 = math.sin(math.atan2(TenTY, tenTX))

        //print(tenTX);
        //print(tenTY);
        //float xPos = startTouch.x - Input.mousePosition.x;
        //float yPos = startTouch.y - Input.mousePosition.y;


        Vector2 positionToCompute = new Vector2(
            Mathf.Sin(Mathf.Atan2(tenTY, tenTX)),
            Mathf.Cos(Mathf.Atan2(tenTY, tenTX))
            );
        mPlayerMovement.SetForcePosition(new Vector3(positionToCompute.y, 0, positionToCompute.x));
    }

    float RandomZeroToOneWithDec()
    {
        float rand = Random.Range(0, 2);

        if (rand == 0)
        {
            //string randInit = ;
            //float specificFloat = float.Parse(randInit);
            return float.Parse(rand.ToString() + "." + Random.Range(1, 10).ToString());

        } else
        {
            return rand;
        }
    }
    void ShootEnemy()
    {
        mPlayerMovement.SetMoveForce(RandomZeroToOneWithDec());
        mPlayerMovement.MoveForce();
    }
    // Start is called before the first frame update
    void Start()
    {
        mPlayerMovement = GetComponent<PlayerMovement>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void EnemyTurn()
    {
        imaginaryAiming = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (mPlayerMovement != null)
            EnemyAim();


        if (imaginaryAiming == true)
        {
            aimingCounter += Time.deltaTime;

            if (aimingCounter >= 1f)
            {
                imaginaryAiming = false;
                ShootEnemy();
            }
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    
        //}
    }
}
