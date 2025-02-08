using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction Boost;
    [SerializeField] InputAction Rotation;
    [SerializeField] float BoostAcceleration = 100.0f;
    
    void Start()
    {
        
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
