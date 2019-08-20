using UnityEngine;
using UnityEngine.Assertions;

[SelectionBase]
public class PlayerInput : MonoBehaviour
{
    private Camera playerCamera; // Default value is null
    private Flipper leftFlipper;
    private Flipper rightFlipper;

    private const string leftFlipperName = "LeftFlipper";
    private const string rightFlipperName = "RightFlipper";

    #region Unity methods
    // functions/methods
    // access modifiers, return datatype, method name, parameters
    private void Awake()
    {
        playerCamera = Camera.main; // Camera.main uses find object of tag internally, super rude.
        leftFlipper = GetFlipper(leftFlipperName);
        Assert.IsNotNull(leftFlipper, "Child: " + leftFlipperName + " was not found!");

        rightFlipper = GetFlipper(rightFlipperName);
        Assert.IsNotNull(rightFlipper, "Child: " + rightFlipperName + " was not found!");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        float xPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        leftFlipper.isPressed = Input.GetButton(leftFlipperName);
        rightFlipper.isPressed = Input.GetButton(rightFlipperName);
    }
    #endregion Unity methods 

    private Flipper GetFlipper(string flipperName)
    {
        //Transform flipperTransform = transform.Find(flipperName);
        //Assert.IsNotNull(flipperTransform, "Child: " + flipperName + " was not found!");
        //Flipper flipper = flipperTransform.GetComponent<Flipper>();
        //Assert.IsNotNull(flipper, "Child: " + flipperName + " missing Flipper script!");

        return transform.Find(flipperName)?.GetComponent<Flipper>(); // Same as above
    }
}