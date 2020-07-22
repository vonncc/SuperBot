using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowdownNumber = 0.05f;

    public bool isSlowingdown;

    public void DoSlowMotion()
    {
        Time.timeScale = slowdownNumber;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
