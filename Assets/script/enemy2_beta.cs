using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy2_beta : MonoBehaviour
{

    //public GameObject Player;

    public GameObject Player;
    public playe_beta PlayerCod;

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
        transform.position = new Vector3(start.x +X, start.y+ 3*Y, -1);
        Player    = GameObject.FindGameObjectWithTag("Player");
        PlayerCod = Player.GetComponent<playe_beta>();
    }



    // Update is called once per frame
    void Update()
    {   
        
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
//mates
    bool rectaM (Vector2 Rplayer, Vector2 R2 )
    {
        double r, s, t;
        r = Math.Round((Rplayer.x - R2.x)/(Rplayer.y - R2.y));
        s = Math.Round((Rplayer.x - (Rplayer.x+X))/(Rplayer.y - (Rplayer.y+Y*3)));
        t = Math.Round((Rplayer.x - (Rplayer.x-X))/(Rplayer.y - (Rplayer.y+Y*3)));
        return r==s||r==t;
    }
    bool viendo (float num,Vector2 R1,  Vector2 R2 )
    {
         //0 = SO || 1 = SE || 2 = NE || 3 = NO    
        return 
         (num == 0 && R2.x < R1.x && R2.y < R1.y) ||
         (num == 1 && R2.x > R1.x && R2.y < R1.y) ||
         (num == 2 && R2.x > R1.x && R2.y > R1.y) || 
         (num == 3 && R2.x < R1.x && R2.y > R1.y);
            
        
    }
    IEnumerator EsperarSegundos(float segundos)
    {
        esp = true;
        yield return new WaitForSeconds(segundos);
        if(!(rectaM(Player.transform.position ,transform.position) && viendo(PlayerCod.Vista, Player.transform.position, transform.position)))
            transform.Translate(dir, Space.World );
        esp = false;
    }
    



}