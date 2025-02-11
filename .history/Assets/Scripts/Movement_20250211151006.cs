using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction BoostInput;
    [SerializeField] InputAction RotationInput;
    [SerializeField] float BoostAcceleration = 100.0f;
    [SerializeField] float RotationAcceleration = 100.0f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;


    Rigidbody mainRB;
    AudioSource audioSource;

    void Start()
    {
        mainRB = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        {
            mainRB.AddRelativeForce(Vector3.up * BoostAcceleration * Time.fixedDeltaTime);
            
            if (!audioSource.isPlaying) audioSource.PlayOneShot(mainEngineSFX);
            if (!mainEngineParticles.isPlaying) mainEngineParticles.Play();

        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
        }
            
    }

    private void CheckRocketRotation()
    {
        float RotationValue = RotationInput.ReadValue<float>();

        if(RotationValue < 0) // Left Rotate
        {
            AddRotation(RotationAcceleration);
            if (!rightThrustParticles.isPlaying)
            {
                leftThrustParticles.Stop();
                rightThrustParticles.Play();
            }

        }
        else if(RotationValue > 0) // Right Rotate
        {
            AddRotation(-RotationAcceleration);
            if (!leftThrustParticles.isPlaying)
            {
                rightThrustParticles.Stop();
                leftThrustParticles.Play();
            }
        }
        else
        {

        }
    }

    private void AddRotation(float Speed)
    {
        mainRB.freezeRotation = true;
        transform.Rotate(Vector3.forward * Speed * Time.fixedDeltaTime);
        mainRB.freezeRotation = false;
    }
}
