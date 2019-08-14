using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Data types and variables
    // Creating a variable
    // access modifier - data type - variable name

    // access modifiers: public, private, protected
    // if no access modifier it is private

    // public int myValue; // Declaring a variable
    public int myvalue = 10; // declaring and initializing a variable. this is a member variable
    public bool isdead = false;

    private float speed = 10.5f; // 10.0f == 10f
    private double precisionspeed = 10.5;
    private string myname = "fredrik";
    private char mychar = 'f';

    /* Data types
     * int = whole numbers
     * bool = true or false
     * float = decimals ~7
     * double = decimals with more precision. ~15
     * string = text or a string of characters
     * char = one character
     */
    #endregion Data types and variables

    private Camera playerCamera; // Default value is null

    // functions/methods
    // access modifiers, return datatype, method name, parameters
    private void Awake()
    {
        playerCamera = Camera.main; // Camera.main uses find object of tag internally, super rude.
    }

}
