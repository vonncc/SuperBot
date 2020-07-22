using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public bool canShoot;
    public float playerMoveForce = 1f;
    public LineAim lineAim;
    public float slowdownTimeFactor = 0.5f;
    Vector2 startTouch;
    Vector2 endTouch;

    Vector2 positionToCompute;

    public RectTransform arrow;

    public PlayerMovement playerMovement;
    public PlayerBehaviour playerBehaviour;

    void UpdateTouchVariables(ref Vector2 pPosition)
    {
        pPosition = Input.mousePosition;
        
    }
    public void OnDragBegan()
    {
        //print("BEGAN");
        if (canShoot == true)
        {
            lineAim.DisplayLine(true);
            UpdateTouchVariables(ref startTouch);
            arrow.position = new Vector2(startTouch.x, startTouch.y);
        }
        
        //startTouch = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //print(Input.mousePosition);
    }

    public void OnDragEnded()
    {
        //print("ENDED");
        if (canShoot == true)
        {
            canShoot = false;
            lineAim.DisplayLine(false);
            UpdateTouchVariables(ref endTouch);
            playerMovement.MoveForce();
            //playerBehaviour.spawnCircle = true;
        }
        
        //ReturnTime();
        //print(Input.mousePosition);
    }

    void SlowDownTime()
    {
        //Time.fixedDeltaTime = 0;
        Time.timeScale = slowdownTimeFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    void ReturnTime()
    {
        Time.timeScale = 1;
    }
    public void OnDragHold()
    {
        //print("HOLD");
        //print(Input.mousePosition);
        //print(startTouch);
        
        float tenTX = Input.mousePosition.x - startTouch.x;
        float tenTY = Input.mousePosition.y - startTouch.y;

        //                    local t1 = math.cos(math.atan2(TenTY, tenTX))

        //                    local t2 = math.sin(math.atan2(TenTY, tenTX))

        //print(tenTX);
        //print(tenTY);
        //float xPos = startTouch.x - Input.mousePosition.x;
        //float yPos = startTouch.y - Input.mousePosition.y;
        positionToCompute = new Vector2(
            Mathf.Sin(Mathf.Atan2(tenTY, tenTX)),
            Mathf.Cos(Mathf.Atan2(tenTY, tenTX))
            );
        playerMovement.SetForcePosition(new Vector3(positionToCompute.y * -1, 0 , positionToCompute.x * -1));
        float computedAngle = Mathf.Atan2(tenTX, tenTY * -1) * Mathf.Rad2Deg;

        
        //arrow.localEulerAngles = new Vector3(0, 0, computedAngle * -1);
        lineAim.UpdateAimRotation(new Vector3(0, computedAngle * -1, 0));

        //float xPosCalculate = startTouch.x - Input.mousePosition.x
        //float yPosCalculate = 100;
        float distance = Mathf.Sqrt(Mathf.Pow(tenTX, 2) + Mathf.Pow(tenTY, 2));

        float maximumValue = 200;
        float lineLength = Mathf.Clamp(Mathf.Abs(distance), 0, maximumValue);
        float getPercentage = lineLength / maximumValue;
        //print(Mathf.Abs(distance));
        lineAim.UpdateLineLength(getPercentage);

        playerMovement.SetMoveForce(getPercentage);
        //print(positionToCompute);
        //SlowDownTime();

        //lineRenderer.SetPosition(1, );
    }
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        playerMovement.SetMoveForce(0);
    }

    // Update is called once per frame
    void Update()
    {
        //lineRenderer.SetPosition(0, );

        
        //print(Time.timeScale);
    }
}
