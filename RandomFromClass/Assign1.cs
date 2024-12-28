using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.
//currently this code drive the car according to the arrowkeys.

public class Assign1 : MonoBehaviour
{
    public GameObject fuel;
    public float speed;//scalar
    private Vector2 directionU = new Vector2(0.0f, 0.1f);//x y directions for up
    //private Vector2 directionD = new Vector2(0.0f, -0.1f);//x y directionsv for down//commented out to support nesting
    private Vector2 directionR = new Vector2(0.1f, 0.0f);//x y directions for left
    //private Vector2 directionL = new Vector2(0.1f, 0.0f);//x y directions for right//commented out to support nesting <-I think


    private void Start()//Unused for now
    {
        // speed = 0.1f;//f indicates floating point value
        //direction = fuel.transform.position - this.transform.position;//vector//duh

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
        else if (Input.GetKey(KeyCode.DownArrow))//Using elseif removes the ability to move diagonally
        {
            position.y = position.y - directionU.y;//instead of its own direction I just subtracted the down direction
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x = position.x - directionR.x;//instead of its own direction I just subtracted the right direction
                                                   // position.y = position.y + directionR.y;//unnecessarey
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x = position.x + directionR.x;
        }
        this.transform.position = position;

    }

}