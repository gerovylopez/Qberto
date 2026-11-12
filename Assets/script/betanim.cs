using System;
using UnityEngine;

public class betanim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float j = 0;
    float i = 0;
    float x = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.J)){
            while (j<120){
                i = j*Mathf.Deg2Rad;
                transform.position= new Vector3((float)Math.Sin(i)+x, (float) Math.Cos(i)+x, -1);
                j++;
            }
                j=0;
         }
        
    }
}
