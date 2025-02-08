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
    void Update()
    {
        if(Boost.IsPressed())
        {
            Debug.Log("Dang, I need some space");
        }  

    }
}
