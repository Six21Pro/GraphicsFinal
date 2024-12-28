using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords : MonoBehaviour
{


    public float x;
    public float y;
    public float z;

    public Coords(float x, float y)
    {
        this.x = x;//local variable x refers to global variable x
        this.y = y;
    }

    public Coords(float x, float y,float z)
    {
        this.x = x;//local variable x refers to global variable x
        this.y = y;
        this.z = z;
    }

    public Coords(Vector3 vecpos)//will accept a vector object and break it down into coordinates
    {
        this.x = vecpos.x;//local variable x refers to global variable x
        this.y = vecpos.y;
        this.z = vecpos.z;
    }

    public override string ToString()
    {
        return("("+x+","+y+","+z+")");
    }
    public Vector3 ToVector()
    {
        return new Vector3(x,y,z);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
