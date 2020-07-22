using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public CameraManager cameraManager;
    public bool spawnCircle;
    public GameObject circleMark;
    GameManagerScript gameManagerScript;
    Rigidbody mRigidybody;

    //TouchManager mTouchManager;

    public delegate void OnFinishPanning();
    // Start is called before the first frame update
    void Start()
    {
        mRigidybody = GetComponent<Rigidbody>();
        //mTouchManager = GameObject.FindGameObjectWithTag("TouchManager").GetComponent<TouchManager>();
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Time.timeScale = 0;
            gameManagerScript.GameOver();
            print("GAME OVER");
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Wall")
        {
            mRigidybody.velocity = Vector3.zero;
        }
    }


    void SpawnCircle()
    {
        spawnCircle = false;
        
        GameObject markerObject = Instantiate(circleMark, new Vector3(transform.position.x, -0.5f, transform.position.z), Quaternion.identity);
        markerObject.GetComponent<Transform>().localEulerAngles = new Vector3(90, 0, 0);
        

        OnFinishPanning onFinishPanning = () => {
            //mTouchManager.canShoot = true;
            gameManagerScript.ChangeTurn();
        };
        cameraManager.LookOtherCamera(onFinishPanning, gameManagerScript.GetCurrentTurn());
        //cameraMain.SetActive(false);
    }

    private void FixedUpdate()
    {
        var velocity = mRigidybody.velocity;
        //print(velocity.magnitude);

        if (velocity.magnitude < 2f)
        {
            mRigidybody.velocity = Vector3.zero;
            if (spawnCircle == true)
                SpawnCircle();
        } else
        {
            spawnCircle = true;
        }
        //if (mRigidybody.a)
    }
}
