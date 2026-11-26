using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playe_beta1 : MonoBehaviour
{

    public Vector3  dir;
    
    float X = (float)Math.Sqrt(2)/2;
    float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2;
    float Z = (float)Math.Tan(30*Mathf.Deg2Rad);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.D)){
                dir.y = Y;
                dir.x = X;
                dir.z = Z;
            }
            else if (Input.GetKeyDown(KeyCode.A)){
                dir.y = -Y;
                dir.x = -X;
                dir.z = -Z;
            }
            else if (Input.GetKeyDown(KeyCode.W) ){
                dir.y = Y;
                dir.x = -X;
                dir.z = Z;
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                dir.y = -Y;
                dir.x = X;
                dir.z = -Z;
            }
            else{
                dir.y = 0;
                dir.x = 0;
                dir.z = 0;
            }

       transform.Translate(dir, Space.World );
    }
    //malla
    

    
}