using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is looking good!");
                break;
            case "Landing":
                Debug.Log("You're all done, welcome to our country");
                break;
            default:
                Debug.Log("You crashed dummy");
                break;
        }
    }

}
