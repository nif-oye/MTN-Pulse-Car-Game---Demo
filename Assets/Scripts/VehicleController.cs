using UnityEngine;
using UnityEngine.EventSystems;

public class VehicleController : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float deceleration = 7f;
    public float steerSpeed = 50f;
    public float brakePower = 15f;

    private float currentSpeed = 0f;

    private bool isAccelerating = false;
    private bool isBraking = false;
    private bool isSteeringLeft = false;
    private bool isSteeringRight = false;

    void Update()
    {
        if (GameManager.instance.isGameActive)
        {
            movePlayer();
            steerPlayer();
        }
    }

    void movePlayer()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || isAccelerating)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || isBraking)
        {
            currentSpeed -= brakePower * Time.deltaTime;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed / 2, maxSpeed);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }


    void steerPlayer()
    {
        float steer = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || isSteeringLeft)
        {
            steer = -steerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || isSteeringRight)
        {
            steer = steerSpeed * Time.deltaTime;
        }

        transform.Rotate(0, steer, 0);
    }


    public void OnAccelerateButtonPressed() => isAccelerating = true;
    public void OnAccelerateButtonReleased() => isAccelerating = false;

    public void OnBrakeButtonPressed() => isBraking = true;
    public void OnBrakeButtonReleased() => isBraking = false;

    public void OnSteerLeftButtonPressed() => isSteeringLeft = true;
    public void OnSteerLeftButtonReleased() => isSteeringLeft = false;

    public void OnSteerRightButtonPressed() => isSteeringRight = true;
    public void OnSteerRightButtonReleased() => isSteeringRight = false;
}
