using UnityEngine;

public class CraneRotate : MonoBehaviour
{
    public float startAngle = -90f;
    public float endAngle = 90f;
    public float rotationSpeed = 10f;

    public float currentAngle;
    public bool isRotating;
    public bool isCollided = false;
    public bool isAtDropPoint = false;

    void Start()
    {
        ResetRotation();
    } 

    void Update()
    {
        if (!isRotating) return;

        currentAngle += rotationSpeed * Time.deltaTime;

        if (currentAngle >= endAngle)
        {
            isAtDropPoint = true;
            rotationSpeed *= -1;
        }
        else if (currentAngle <= startAngle)
        {
            rotationSpeed *= -1f;
        }
        

        transform.localRotation = Quaternion.Euler(0f, currentAngle, 0f);
    }

    public void ResetRotation()
    {
        currentAngle = startAngle;
        transform.localRotation = Quaternion.Euler(0f, currentAngle, 0f);
    }

    public void StartRotation()
    {

        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }
}

