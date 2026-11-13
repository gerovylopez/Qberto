using System;
using Unity.Mathematics;
using UnityEngine;

public class playe_beta : MonoBehaviour
{

    private SpriteRenderer sptrender;
    public  Sprite[] skins;

    public  Vector2  dir;
    public  Vector2  checkpoint;
    
    public  float Vista = 0;
    //0 = SO || 1 = SE || 2 = NE || 3 = NO    
    public  float X = (float)Math.Sqrt(2)/2;     
    public  float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2; //tan(pi/6)*2^0.5)*1.5
    //float Z = (float)Math.Tan(30*Mathf.Deg2Rad))/2;
  
    Vector2 camara;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
        tag="Player";
        checkpoint = transform.position;
        
        //transform.position = new Vector3(2*X, 8.5f*Y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
        //0 = SO || 1 = SE || 2 = NE || 3 = NO     
        if (Input.GetKeyDown(KeyCode.A)){
            Vista = 0;
            dir.y = -3*Y;
            dir.x = -X;
            if(skins[0])
                sptrender.sprite = skins[0];
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            Vista = 1;
            dir.y = -3*Y;
            dir.x = X;
            if(skins[1])
                sptrender.sprite = skins[1];
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            Vista = 2;
            dir.y = 3*Y;
            dir.x = X;
            if(skins[2])
                sptrender.sprite = skins[2];//
        }
        else if (Input.GetKeyDown(KeyCode.W) ){
            Vista = 3;
            dir.y = 3*Y;
            dir.x = -X;
            if(skins[3])
                sptrender.sprite = skins[3];//
        }
        else{
            dir.y = 0;
            dir.x = 0;
        }
        if(Input.GetKey(KeyCode.LeftShift))
            transform.Translate(2*dir, Space.World);
        else
            transform.Translate(dir, Space.World);
        
        camara = GameObject.FindGameObjectWithTag("Camera").transform.position;
/*
        if(math.round(camara.y/Y)%2==0)
            checkpoint =new Vector2(0, camara.y -3*6*Y);
        else
            checkpoint =new Vector2(0, camara.y  -2.5f*6*Y );
  */      

        if (transform.position.y < camara.y-12 || transform.position.x < camara.x-8||transform.position.x > camara.x+12)
            transform.position =  checkpoint;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemyv")||other.CompareTag("Enemy")||other.CompareTag("Outside")||other.CompareTag("Roca"))
        {
            transform.position = checkpoint;
            GameObject.FindGameObjectWithTag("Camera").transform.position =new Vector3(0, transform.position.y +5,-3);
        }
    
        if (other.CompareTag("Checkpoint"))
            checkpoint=transform.position;
    }/*
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Casilla"))
        {
            Debug.Log("Cooked" + other.name);
            transform.position = new Vector3(X, 5.5f*Y, -1);
        }
    }
*/
}