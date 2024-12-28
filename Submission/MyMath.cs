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

    //Position is the current location of the object to be translated
    //Vectir is the amount of 
    /*public static Coords Translate(Coords pos1, Coords vector)
    {
        Debug.Log("Translate method Position " + pos1);
        /*if( position == null)
         {
            Debug.LogError("Null reference detected in Translate method. Position or vector is null.");
            return null;
            }*/
    /*

        Debug.Log("Input Position: " + pos1 + ", Vector: " + vector);

        float[] translateValues = { 1, 0, 0, vector.x, 
            0, 1, 0, vector.y, 
            0, 0, 1, vector.z, 
            0, 0, 0, 1 };
        Matrix translateMatrix = new Matrix(4, 4, translateValues);
        Debug.Log(translateMatrix.ToString()+"\n");
        Matrix pos = new Matrix(4, 1, pos1.AsFloats());
        Matrix result = translateMatrix * pos;
        //Debug.Log(result.ToString());
     
        return result.AsCoords();
    }*/

    /*static public Coords Scale(Coords position, float scaleX,float scaleY, float scaleZ)
    {
        float[] scaleValues = { scaleX, 0, 0, 0,
            0, scaleY, 0, 0,
            0, 0, scaleZ, 0,
            0, 0, 0, 1 };
        Matrix scaleMatrix = new Matrix(4, 4, scaleValues);
        Debug.Log(scaleMatrix.ToString() + "\n");
        Matrix pos = new Matrix(4, 1, position.AsFloats());
        Matrix result = scaleMatrix * pos;
        // Debug.Log(result.ToString());
        return result.AsCoords();
    }*/

    /*static public Coords RotateX(Coords position, float angleX)
    {
        float[] xRollValues = { 1, 0, 0, 0,
            0, Mathf.Cos(angleX), -Mathf.Sin(angleX), 0,
            0, Mathf.Sin(angleX), Mathf.Cos(angleX), 0,
            0, 0, 0, 1 };
        Matrix rotateMatrix = new Matrix(4, 4, xRollValues);
        Debug.Log(rotateMatrix.ToString() + "\n");
        Matrix pos = new Matrix(4, 1, position.AsFloats());
        Matrix result = rotateMatrix * pos;
        // Debug.Log(result.ToString());
        return result.AsCoords();
    }*/




    


    //he had this stuff in a matrix script
    float[] values;
    int rows;
    int cols;

    //public class Matrix{should contain the below}
    /* public Matrix(int r, int c, float[] v)
     {
         rows = r;
         cols = c;
         values = new float[rows * cols];
         Array.Copy(v, values, rows * cols);
     }

     public override string ToString()
     {

         string matrix = " ";
         for(int c = 0; c < cols; c++)
         {

         }
         return matrix;

     }*/
}
