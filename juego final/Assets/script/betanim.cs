using System;
using UnityEngine;

public class betanim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float j = 0;
    float i = 0;
    float x = 10;
    float y = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        i = j*Mathf.Deg2Rad;
        transform.position= new Vector3(-(float)Math.Sin(i)+x, (float) Math.Cos(i)+x, -1);
        j++;
        if (j>120)
            j=120;
        if (Input.GetKeyDown(KeyCode.J)){
            j=0;
            x=transform.position.x;
            y=transform.position.y;
        }
        
    }
}
