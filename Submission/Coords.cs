using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords : MonoBehaviour
{


    public float x;
    public float y;
    public float z;
    public float w;

    public Coords(float x, float y)
    {
        this.x = x;//local variable x refers to global variable x
        this.y = y;
    }

    public Coords(float x, float y,float z)//possibly need to copy and paste this to include w
    {
        this.x = x;//local variable x refers to global variable x
        this.y = y;
        this.z = z;
    }
    public Coords(float x, float y, float z,float w)//possibly need to copy and paste this to include w
    {
        this.x = x;//local variable x refers to global variable x
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public Coords(Vector3 vecpos,float w)
    {
        this.x = vecpos.x;//local variable x refers to global variable x//12/4
        this.y = vecpos.y;//12/4
        this.z = vecpos.z;//12/4
        this.w = w; 
    }
    public float[] AsFloats()
    {
        float[] values = { x, y, z, w };
        return values;
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


 
}
