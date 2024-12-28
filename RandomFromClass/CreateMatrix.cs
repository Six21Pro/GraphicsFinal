using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {
        float[] vals = { 1, 2, 3, 4, 5, 6 };
        float[] vals2 = { 1, 1,1,1 };
        Matrix m = new Matrix(2, 3, vals);
        Matrix m2 = new Matrix(2, 3, vals2);
        float[] nvals = { 1, 1, 1, 2, 2, 2 };
        float[] nvals2 = { 2,3,2,3 };
        Matrix n = new Matrix(2, 3, nvals);
        Matrix n2 = new Matrix(2, 3, nvals2);
        Matrix answer = m + n;
        Matrix answer2 = m * n;
        Debug.Log(m.ToString()+"\n"+n.ToString());
        Debug.Log("The result is ");
        Debug.Log(answer.ToString());

        Debug.Log(m2.ToString() + "\n" + n2.ToString());
        Debug.Log("The result is ");
        Debug.Log(answer2.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
