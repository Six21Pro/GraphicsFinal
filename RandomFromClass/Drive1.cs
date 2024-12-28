using UnityEngine;
using System.Collections;

// A very simplistic 'car' driving on the x-z plane.

public class Drive1 : MonoBehaviour
{
    public GameObject fuel;
    public float speed;//scalar
   
    public Vector3 direction;//9/10
    public float stoppingDistance;//9/10
    public float distanceToFuel;//9/10
    public Coords dirNormal;//9/24

    private void Start()
    {
        this.transform.up = MyMath.LookAt2D(new Coords(this.transform.up), new Coords(this.transform.position),
            new Coords(fuel.transform.position)).ToVector();//9/26
        // speed = 0.1f;//f indicates floating point value
        //direction = fuel.transform.position - this.transform.position;//vector//duh
        direction = fuel.transform.position - this.transform.position;//9/10
        Coords vecCoordinates = new Coords(direction);
        //Coords vecCoordinates = MyMath.Normalize(new Coords(direction));//9/17//comout 9/24

        Debug.Log("Before normalizing"+direction);//9/24
        dirNormal = MyMath.Normalize(vecCoordinates);
        Debug.Log("After normalizing"+dirNormal.ToVector());//9/24

       // Coords dirNormal = MyMath.Normalize(vecCoordinates);//9/17//comout 9/24
        Coords vectorUp = new Coords(0, 1, 0);//9/19
        float angle = MyMath.Angle(dirNormal, vectorUp);//9/19

        Coords crossProduct = MyMath.CrossProduct(vectorUp, dirNormal);//9/24
        Debug.Log("Vector CrossProduct" + crossProduct.ToVector());
        bool turnDir = false;
        if(crossProduct.ToVector().z < 0)
        {
            turnDir = true;
        }
        Debug.Log("turnDirection" + turnDir);
        

        Debug.Log("Angle in degrees" + 180 / Mathf.PI * angle);//9/19
        Coords rotatedVector = MyMath.Rotate(vectorUp, angle, turnDir);//9/26 added turnDir
        this.transform.up = new Vector3(rotatedVector.x, rotatedVector.y, rotatedVector.z);

    }

    /*void swap(int x, int y) //HE SHOWED THIS TO HIGHLIGHT ITS KINDA NONSENSE
    {
        x = x;//should be this.x=x;
        y = y;//and likewise
    }
    */
    void Update()
    {


        distanceToFuel = Vector3.Distance(this.transform.position, fuel.transform.position); //9/10
        if (distanceToFuel > stoppingDistance) //9/10
            this.transform.position = this.transform.position + speed * dirNormal.ToVector();//9/10//changed from direction to dirNo
        // Vector3 direction = fuel.transform.position - this.transform.position;//vector//duh
        //this.transform.position=this.transform.position + speed*direction;//He has been making many changes


        /*
      Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.UpArrow)) {//was space
            position.x = position.x + directionU.x;
            position.y = position.y + directionU.y;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {//was space
            position.x = position.x + directionD.x;
            position.y = position.y + directionD.y;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {//was space
            position.x = position.x + directionL.x;
            position.y = position.y + directionL.y;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {//was space
            position.x = position.x + directionR.x;
            position.y = position.y + directionR.y;
        }
        this.transform.position = position;
         */
    }

}