
using UnityEngine;

public class LineAim : MonoBehaviour
{

    public GameObject lineGameObject;
    LineRenderer mLineRenderer;
    Transform lineTransform;

    float lineMaximumLength = 5f;
    // Start is called before the first frame update

    private void Awake()
    {
        mLineRenderer = lineGameObject.GetComponent<LineRenderer>();
        lineTransform = lineGameObject.GetComponent<Transform>();
        DisplayLine(false);
    }

    public void UpdateAim(Vector3 pAimPos)
    {
        mLineRenderer.SetPosition(1, pAimPos);
    }

    public void UpdateLineLength(float pLength)
    {
        lineGameObject.SetActive(true);
        UpdateAim(new Vector3(0,0, lineMaximumLength * pLength));
    }

    public void UpdateAimRotation(Vector3 pAimRota)
    {
        lineGameObject.SetActive(true);
        lineTransform.localEulerAngles = pAimRota;
    }

    public void DisplayLine(bool pLineStatus)
    {
        UpdateAimRotation( new Vector3(0,0,0));
        lineGameObject.SetActive(pLineStatus);
    }


    //public
}
