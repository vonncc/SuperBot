using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody mRigidbody;

    public float maxPower = 50f;
    private float movePower = 100f;
    private Vector3 forcePosition;

    public void SetMoveForce(float pMovePercentage)
    {
        if (mRigidbody != null)
        {
            //mRigidbody.velocity = Vector3.zero;
            float moveP = maxPower * pMovePercentage;
            movePower = moveP;
            //mRigidbody.velocity = Vector3.zero;
        }
        
    }

    public void SetForcePosition(Vector3 pForcePos)
    {
        forcePosition = pForcePos;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void MoveForce()
    {
        if (mRigidbody != null)
        {
            mRigidbody.velocity = Vector3.zero;
            Vector3 forcePowerPosition = forcePosition * movePower;
            //mRigidbody.AddForceAtPosition(forcePowerPosition, forcePosition, ForceMode.Impulse);
            mRigidbody.AddForce(forcePowerPosition, ForceMode.Impulse);
        }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(mRigidbody.velocity);
        //mRigidbody.velocity = Vector3.zero;
        //mRigidbody.AddForce(Vector3.forward * movePower);
    }
}
