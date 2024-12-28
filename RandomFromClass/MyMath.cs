using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMath : MonoBehaviour//his doesn't say monobehavior
{//MyMath.normalize(new Coords(5,3,0));
    static public Coords Normalize(Coords vector)
    {
        float magnitude = Distance(new Coords(0,0,0), vector);//length should porbably be named magnitued
        vector.x /= magnitude;
        vector.y /= magnitude;
        vector.z /= magnitude;
        return vector;
    }

    static public float Distance(Coords point1,Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) + Square(point1.y - point2.y);//could ytake apart and put in return
       
        return Mathf.Sqrt(diffSquared);

    }

    static public float DotProduct(Coords vector1,Coords vector2) //returns a scalar
    { 
        return (vector1.x*vector2.x + vector1.y*vector2.y+vector1.z*vector2.z);
    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public Coords Rotate(Coords vector, float angle, bool turn)//removed bool clockwise
    {
        if (turn==true)
        {
            angle = -2*Mathf.PI - angle;
        }
        float newX = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float newY = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(newX, newY,0);

    }

    static public Coords CrossProduct(Coords vector1, Coords vector2) //returns a scalar//should be Coords and not float?
    {

        float xMult = vector1.y * vector2.z - vector2.y * vector1.z;
        float yMult = vector1.x * vector2.z - vector2.x * vector1.z;
        float zMult = vector1.x * vector2.y - vector2.x * vector1.y;

        //float result = ((vector1.y * vector2.z - vector2.y * vector1.z), (vector1.x * vector2.z - vector2.x * vector1.z)
        //  ,(vector1.x * vector2.y - vector2.x * vector1.y));
        return new Coords(xMult, yMult, zMult); 
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        //first possible way to do this
        float dotDivide = DotProduct(vector1, vector2) /
            (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));

        //second way to do this
        vector1 = Normalize(vector1);
        vector2 = Normalize(vector2);
        //float dotDivide = DotProduct(vector1, vector2);
        // 
        return Mathf.Acos(dotDivide);
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, 0.0f);
        direction = MyMath.Normalize(direction);
        float angle = MyMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if(MyMath.CrossProduct(forwardVector, direction).z < 0)
        {
            clockwise = true;
        }
        Coords newDir = MyMath.Rotate(forwardVector, angle,clockwise);//removed clockwise
        return newDir;
    }

    


    // Start is called before the first frame update
    private void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
