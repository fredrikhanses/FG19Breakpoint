using UnityEngine;
using UnityEngine.Assertions;

public class Flipper : MonoBehaviour
{
    public float flipperspeed = 1000f;
    public float reverseMod = 1f;

    [System.NonSerialized] public bool isPressed = false; // Hidden in Unity Editor, also [HideInInspector]
    
    private HingeJoint2D hinge;
    
    private void Awake() // First thing that runs
    {
        hinge = GetComponent<HingeJoint2D>(); // if not found, hinge = null
        Assert.IsNotNull(hinge, "Could'nt find the hinge component."); // This will only run in debug mode
    }

    private void FixedUpdate() // Used for physics based instructions
    {
        if (isPressed)
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * flipperspeed;
            hinge.motor = motor;
        }
        else
        {
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * -flipperspeed;
            hinge.motor = motor;
        }
    }
}