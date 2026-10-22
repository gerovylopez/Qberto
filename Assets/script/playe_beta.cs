using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playe_beta : MonoBehaviour
{

    public Vector3  dir;
    
    float X = (float)Math.Sqrt(2)/2;
    float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2;
    //float Z = (float)Math.Tan(30*Mathf.Deg2Rad))/2;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.D)){
                dir.y = 3*Y;
                dir.x = X;
            }
            else if (Input.GetKeyDown(KeyCode.A)){
                dir.y = -3*Y;
                dir.x = -X;
            }
            else if (Input.GetKeyDown(KeyCode.W) ){
                dir.y = 3*Y;
                dir.x = -X;
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                dir.y = -3*Y;
                dir.x = X;
            }
            else{
                dir.y = 0;
                dir.x = 0;
            }
            dir.z=0;

       transform.Translate(dir, Space.World );
    }
    //malla
    

    
}