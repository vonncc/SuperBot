
using UnityEngine;

public class BallFollower : MonoBehaviour
{
    public Transform ballTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ballTransform != null)
            transform.position = new Vector3(ballTransform.position.x, ballTransform.position.y, ballTransform.position.z);
    }
}
