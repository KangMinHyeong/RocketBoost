using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction Boost;
    [SerializeField] InputAction Rotation;
    [SerializeField] float BoostAcceleration = 100.0f;

    Rigidbody mainRB;

    void Start()
    {
        mainRB = GetComponent<Rigidbody>();
    }

    private void OnEnable() 
    {
        Boost.Enable();
        Rotation.Enable();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if(Boost.IsPressed())
        {
            mainRB.AddRelativeForce(Vector3.up * BoostAcceleration * Time.fixedDeltaTime);
        }  

    }
}
