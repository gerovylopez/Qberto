using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy_beta : MonoBehaviour
{

    public GameObject Player;

    private SpriteRenderer sptrender;
    public  Sprite[] skins;

    public  Vector2  dir;
    

    
    public  float X = (float)Math.Sqrt(2)/2;     
    public  float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2; //tan(pi/6)*2^0.5)*1.5
    //float Z = (float)Math.Tan(30*Mathf.Deg2Rad))/2;


    public  Vector2 start;
    //public  float lim   = 1;
    //public  float add = 0.25f;
    private bool esp = false;
    public  float time = 0.5f;
    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
        Player    = GameObject.FindGameObjectWithTag("Player");
        //transform.position = new Vector3(start.x * X + X, start.y*3*Y -Y*.5f, -1);
    }



    // Update is called once per frame
    void Update()
    {
        if (transform.position.y< GameObject.FindGameObjectWithTag("Camera").transform.position.y- 10)
            Destroy(gameObject);
        
        if(!esp)
            {
                if (Player.transform.position.y > transform.position.y){
                dir.y = 3*Y;
//                if(skins[3])
//                    sptrender.sprite = skins[3];
            }
            else if (Player.transform.position.y <= transform.position.y){
                dir.y = -3*Y;
//                if(skins[0])
//                    sptrender.sprite = skins[0];
            }
            if (Player.transform.position.x > transform.position.x){
                dir.x = X;
//                if(skins[2])
//                    sptrender.sprite = skins[2];
            }
            else if (Player.transform.position.x <= transform.position.x){
                dir.x = -X;
//                if(skins[1])
//                    sptrender.sprite = skins[1];
            }
        StartCoroutine(EsperarSegundos(time));
        }
/*            else{
                dir.y = 0;
                dir.x = 0;
            }*/

    }
    private void OnTriggerEnter2D(Collider2D other)
    {


    }
    IEnumerator EsperarSegundos(float segundos)
    {
        esp = true;
        yield return new WaitForSeconds(segundos);
        transform.Translate(dir, Space.World );
        esp = false;
    }
    
}