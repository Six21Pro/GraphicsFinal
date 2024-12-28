using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    //public GameObject sphere;
    public GameObject p;//vid12/4
    public Vector3 translation;
    public float scaleX, scaleY, scaleZ;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        //foreach (GameObject p in points)
        {
            if (p == null)
            {
                Debug.Log("GameObject in points array is null.");
                //continue;  // Skip null objects in the points array
            }

            // Log the position of each pointW
            Coords pos = new Coords(p.transform.position, 1f);
            Debug.Log("Position " + pos);
            Coords pos2 = new Coords(5f, 5f, 5f, 5f);
            Coords pos3 = new Coords(p.transform.localScale, 1f);
            //Debug.Log($"Position of point {p.name}: {position4}");

            // Coords vector5 = new Coords(new Vector3(5, 0, 0), 0);
            //Debug.Log($"Translation vector: {vector5}");

            // Now, use Translate method
            p.transform.position = MyMath.Translate(pos, new Coords(new Vector3(translation.x, translation.y, 0))).ToVector();
            p.transform.localScale = MyMath.Scale(pos3, scaleX, scaleY, scaleZ).ToVector();
        }
    }

}
