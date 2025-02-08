using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction BoostInput;
    [SerializeField] InputAction RotationInput;
    [SerializeField] float BoostAcceleration = 100.0f;
    [SerializeField] float RotationAcceleration = 100.0f;

    Rigidbody mainRB;

    void Start()
    {
        mainRB = GetComponent<Rigidbody>();
    }

    private void OnEnable() 
    {
        BoostInput.Enable();
        RotationInput.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckRocketBoost();
        CheckRocketRotation();
    }

    private void CheckRocketBoost()
    {
        if (BoostInput.IsPressed())
            mainRB.AddRelativeForce(Vector3.up * BoostAcceleration * Time.fixedDeltaTime);
    }

    private void CheckRocketRotation()
    {
        float RotationValue = RotationInput.ReadValue<float>();

        if(RotationValue < 0)
        {
            // Left Rotate
            transform.Rotate(-Vector3.forward * RotationAcceleration * Time.fixedDeltaTime);
        }
        else if(RotationValue > 0)
        {
            transform.Rotate(Vector3.forward * RotationAcceleration * Time.fixedDeltaTime);
        }
        if (RotationInput.IsPressed())
            mainRB.AddRelativeForce(Vector3.up * BoostAcceleration * Time.fixedDeltaTime);
    }
    
}
