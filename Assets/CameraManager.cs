using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject overlookingCamera;
    //public Game
    public CinemachineVirtualCamera cineMachineMain;
    public CinemachineVirtualCamera cineMachineOver;
    public CinemachineVirtualCamera cnieMachineEnemy;
    //public 

    public float cameraPanTimer = .5f;


    float cameraCounterPan;
    float returnTimerCounter;
    float endPanTimerCounter;
    float counterBeforeRunning;

    float timerBeforeRunning;
    float timerBeforeReturning;
    float timerBeforeEndPan;

    bool doAnimate;
    bool doWaiting;
    bool inPanning;
    bool doReturning;
    bool waitToEndPan;

    PlayerBehaviour.OnFinishPanning triggerThis;

    int turnIndicator;

    public void LookOtherCamera(PlayerBehaviour.OnFinishPanning pFinishPanning, int pCurrentTurn,float pTimerBeforeRunning = 1f, float pTimerBeforeReturning = 1f)
    {
        triggerThis = pFinishPanning;
        timerBeforeRunning = pTimerBeforeRunning;
        timerBeforeReturning = pTimerBeforeReturning;
        timerBeforeEndPan = pTimerBeforeRunning;
        cameraCounterPan = 0;
        returnTimerCounter = 0;
        endPanTimerCounter = 0;
        counterBeforeRunning = 0;

        doAnimate = true;
        doWaiting = true;
        doReturning = false;
        inPanning = false;
        waitToEndPan = false;
        turnIndicator = pCurrentTurn;
    }

    void ReturnToMainCamera()
    {
        //cameraMain.SetActive(true);
        cineMachineMain.Priority = 10;
        cineMachineOver.Priority = 9;
        cnieMachineEnemy.Priority = 8;
    }

    void ChangeToOverlookCamera()
    {
        //cameraMain.SetActive(false);
        cineMachineMain.Priority = 9;
        cineMachineOver.Priority = 10;
        cnieMachineEnemy.Priority = 8;
    }

    void ChangeToEnemyCamera()
    {
        cineMachineMain.Priority = 8;
        cineMachineOver.Priority = 9;
        cnieMachineEnemy.Priority = 10;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doAnimate == true)
        {
            if (doWaiting == true)
            {
                counterBeforeRunning += Time.deltaTime;

                if (counterBeforeRunning >= timerBeforeRunning)
                {
                    doWaiting = false;
                    ChangeToOverlookCamera();
                    inPanning = true;
                }
            } else
            {
                

                if (inPanning == true)
                {
                    cameraCounterPan += Time.deltaTime;
                    if (cameraCounterPan >= cameraPanTimer)
                    {
                        inPanning = false;
                        doReturning = true;
                    }
                } else
                {
                    if (doReturning == true)
                    {
                        returnTimerCounter += Time.deltaTime;
                        if (returnTimerCounter >= timerBeforeReturning)
                        {
                            doReturning = false;
                            if (turnIndicator == 0)
                                ChangeToEnemyCamera();
                            else
                                ReturnToMainCamera();
                            doAnimate = false;
                            waitToEndPan = true;
                        }
                    }
                }
            }
        } else
        {
            if (waitToEndPan == true)
            {
                endPanTimerCounter += Time.deltaTime;

                if (endPanTimerCounter >= timerBeforeEndPan)
                {
                    waitToEndPan = false;
                    triggerThis();
                }
            }
            
        }
    }
}
