using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playe_beta2 : MonoBehaviour
{

    private SpriteRenderer sptrender;
    public  Sprite[] skins;

    public  Vector3  dir;
    
    public  float X = (float)Math.Sqrt(2)/2;     
    public  float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2; //tan(pi/6)*2^0.5)*1.5
    //float Z = (float)Math.Tan(30*Mathf.Deg2Rad))/2;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.D)){
                dir.y = 3*Y;
                dir.x = X;
                sptrender.sprite = skins[3];//
            }
            else if (Input.GetKeyDown(KeyCode.A)){
                dir.y = -3*Y;
                dir.x = -X;
                sptrender.sprite = skins[0];
            }
            else if (Input.GetKeyDown(KeyCode.W) ){
                dir.y = 3*Y;
                dir.x = -X;
                sptrender.sprite = skins[2];//
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                dir.y = -3*Y;
                dir.x = X;
                sptrender.sprite = skins[1];
            }
            else{
                dir.y = 0;
                dir.x = 0;
            }
            dir.z=0;

       transform.Translate(dir, Space.World );
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("esta on fire");
        if(other.CompareTag("Casilla"))
            Debug.Log("esta on ice");
    }
    //malla



}