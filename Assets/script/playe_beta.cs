using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
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
  
    public float stamina = 100; 
    public float Donas = 0; 
    private bool invulnerable = false;
    public bool staminf = false;
    Vector2 camara;
    Color colorinc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
        tag="Player";
        checkpoint = transform.position;
        colorinc = GetComponent<SpriteRenderer>().color;
        
        //transform.position = new Vector3(2*X, 8.5f*Y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
        //0 A = SO || 1 S = SE || 2 D = NE || 3 W = NO     
        if (Input.GetKeyDown(KeyCode.A)){
            Vista = 0;
            dir.y = -3*Y;
            dir.x = -X;
            movimiento();
            if(skins[0])
                sptrender.sprite = skins[0];
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            Vista = 1;
            dir.y = -3*Y;
            dir.x = X;
            movimiento();
            if(skins[0])
                sptrender.sprite = skins[0];
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.W) ){
            Vista = 3;
            dir.y = 3*Y;
            dir.x = -X;
            movimiento();
            if(skins[1])
                sptrender.sprite = skins[1];
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
            Vista = 2;
            dir.y = 3*Y;
            dir.x = X;
            movimiento();
            if(skins[1])
                sptrender.sprite = skins[1];
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else{
            dir.y = 0;
            dir.x = 0;
        }

        camara = GameObject.FindGameObjectWithTag("Camera").transform.position;

        if(stamina <100)
            stamina+=0.2f;
        
        if (transform.position.y < camara.y-6 || math.abs(transform.position.x) > camara.x+15){
            StartCoroutine(muerte());
        }

            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GameObject.FindGameObjectsWithTag("Casilla")[0])
            Debug.Log("JUsuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");

        if (other.CompareTag("Outside"))
        {
            StartCoroutine(muerte());
            Debug.Log("Cooked" + other.name);
            
        }
        if (!invulnerable&&(other.CompareTag("Enemyv")||other.CompareTag("Enemy")))
        {
            StartCoroutine(muerte());
            Debug.Log("Cooked" + other.name);
            
        }
        if (other.CompareTag("Checkpoint"))
            checkpoint=transform.position;
        if (other.CompareTag("Dona"))
            Donas++;
        if (other.CompareTag("DUFF"))
            StartCoroutine(SegundosStamina(10));
        if (other.CompareTag("Barril"))
            StartCoroutine(SegundosInvul(10));
    }
    IEnumerator SegundosInvul(float segundos)
    {
        invulnerable = true;
        GetComponent<SpriteRenderer>().color =  new Color(1,150,1);
        yield return new WaitForSeconds(segundos);
        GetComponent<SpriteRenderer>().color = colorinc;
        invulnerable = false;
    }
    IEnumerator SegundosStamina(float segundos)
    {
        staminf = true;
        GetComponent<SpriteRenderer>().color =  new Color(150, 1,1);
        yield return new WaitForSeconds(segundos);
        GetComponent<SpriteRenderer>().color = colorinc;
        staminf = false;
        stamina = 100;
    }
    void movimiento()
    {
        if(Input.GetKey(KeyCode.LeftShift) && (stamina>20||staminf)){
            stamina=stamina-20;
            transform.Translate(2*dir, Space.World);
        }
        else if(stamina>10||staminf){
            stamina=stamina-10;
            transform.Translate(dir, Space.World);
        }
    }

    IEnumerator muerte()
    {
        if(skins[4])
            sptrender.sprite = skins[4];
        GetComponent<SpriteRenderer>().flipX = false;
        stamina = 0;
        gameObject.tag = "Respawn";
        yield return new WaitForSeconds(1);
        transform.position =  checkpoint;
        GameObject.FindGameObjectWithTag("Camera").transform.position =new Vector3(0, transform.position.y +2,-5);
        stamina = 100;
        yield return new WaitForSeconds(3);
        gameObject.tag = "Player";
        /*gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = false;*/
        
    }
}