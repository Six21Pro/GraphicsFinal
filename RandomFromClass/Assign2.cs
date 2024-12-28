using UnityEngine;
using System.Collections;
using System.Drawing;



public class Assign2 : MonoBehaviour
{
    public GameObject fuel;
    public float speed = 0.01f;//can be changed within unity
    public Transform target;//tank should circle whatever the target is set to
    public float angle = 206.0f;//this is (roughly) what my initial angle happened to be
    public Vector3 initialPosition; // Variable to store the initial position
    public float r;//r for radius
    //user can change the value of r within unity//dynamically, while the program is running

    private void Start()
    {
        //I created everything in update first with the idea that the tank would rotate the fuel object which I placed at
        //(0,0,0). The below code just catches if a user failed to specify a target object for the tank to circle
        if (target == null)
        {
            GameObject targetObject = new GameObject("Target");//create a new game object
            targetObject.transform.position = Vector3.zero; // Set its position to (0, 0, 0)
            target = targetObject.transform; // Set the target to the targetObject
        }

        initialPosition = transform.position;//this should grab the tank's original position, so that the tank can
                                             //be set back to that position when c is pressed
    }

    
    void Update()
    {
        float x = target.position.x + Mathf.Cos(angle) * r;//These two lines cause the tank to move in a circle
        float y = target.position.y + Mathf.Sin(angle) * r;//as set by an initially determined angle

        transform.position = new Vector3(x, y, 0);//This will set the tank's new position based on Cos and Sin, moving the tank forward
        
        float dx = -r * Mathf.Sin(angle);//equations from the assignment sheet.
        float dy = r * Mathf.Cos(angle);//Should effectively calculate a tangent to determine which way the tank should face

        // Use this vector for what direction the tank will go
        Vector3 direction = new Vector3(dx, dy, 0).normalized;//normalizes a vector calculating the tangent along a circular path

        transform.up = direction; // Using transform.up will set the object's forward direction       
        angle += speed;// this line increments the angle to move the tank around whatever the target is

        // My understanding is that this if statement prevents the angle from exceeding 0 to 360 degrees
        if (angle >= 2 * Mathf.PI)//if angle exceeds or is equal to 360 degrees
        {
            angle -= 2 * Mathf.PI;//subtract 360 degrees (which is 2PI) from the angle
        }

        if (Input.GetKey(KeyCode.C))
        {
            transform.position = initialPosition;//move the tank back to the initial position when c is pressed.
            angle = 206.0f;//without resetting the angle the tank returns to where it was when c is released.
            //So the above line is necessary
        }
    }

}