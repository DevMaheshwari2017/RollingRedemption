using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private float minRotateSpeed, maxRotateSpeed;
    [SerializeField]
    private float minRotateTime, maxRotateTime;
    [SerializeField]
    private GamePlayManager _gm;

    private float currentRotateSpeed;
    private float currentRotateTime;
    private float rotateTime;

    private void Awake()
    {
        RotationSpeed();       
    }

    private void Update()
    {
        currentRotateTime += Time.deltaTime;
        if(currentRotateTime > rotateTime)
        {
            RotationSpeed();
        }
    }

    private void FixedUpdate()
    {
        if (_gm.GetHasGameFinished()) return;
        transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);

    }

    private void RotationSpeed()
    {
        currentRotateTime = 0f;
        // The final value will always be min or max 
        currentRotateSpeed = minRotateSpeed + (maxRotateSpeed - minRotateSpeed) * Random.Range(0, 11) * 0.1f;
        rotateTime = minRotateTime + (maxRotateTime - minRotateTime) * Random.Range(0, 11) * 0.1f;
        // if 0 then 1 if not -1
        currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }
}
