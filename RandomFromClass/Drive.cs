using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.
//currently this code drive the car according to the arrowkeys.

public class Drive : MonoBehaviour
{
    public GameObject fuel;
    public float speed;//scalar
    private Vector2 direction = new Vector2(0.0f, 0.1f);//9/17
    private Vector2 directionU = new Vector2(0.0f, 0.1f);//x y directions for up
    //private Vector2 directionD = new Vector2(0.0f, -0.1f);//x y directionsv for down//commented out to support nesting
    private Vector2 directionR = new Vector2(0.1f, 0.0f);//x y directions for left
    //private Vector2 directionL = new Vector2(0.1f, 0.0f);//x y directions for right//commented out to support nesting <-I think


    private void Start()//Unused for now
    {
        // speed = 0.1f;//f indicates floating point value
        direction = fuel.transform.position - this.transform.position;//vector//duh//9/17
        Coords vecCoordinates = MyMath.Normalize(new Coords(direction));//9/17
        Coords dirNormal = MyMath.Normalize(vecCoordinates);//9/17
        Coords vectorUp = new Coords(0, 1, 0);//9/19
        float angle = MyMath.Angle(dirNormal, vectorUp);//9/19
        Debug.Log("Angle in degrees" + 180/Mathf.PI *angle);//9/19

    }

    void Update()
    {
        // Vector3 direction = fuel.transform.position - this.transform.position;//vector
        //this.transform.position=this.transform.position + speed*direction;//He has been making many changes

        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {//was space
            //position.x = position.x + directionU.x;//unnecessarey
            position.y = position.y + directionU.y;
        }
        if (Input.GetKey(KeyCode.DownArrow))//Using elseif removes the ability to move diagonally
        {
            position.y = position.y - directionU.y;//instead of its own direction I just subtracted the down direction
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x = position.x - directionR.x;//instead of its own direction I just subtracted the right direction
                                                   // position.y = position.y + directionR.y;//unnecessarey
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x = position.x + directionR.x;
        }
        this.transform.position = position;

    }

}