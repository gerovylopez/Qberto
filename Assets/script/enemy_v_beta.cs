using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy_v_beta : MonoBehaviour
{

    private SpriteRenderer sptrender;
    public  Sprite[] skins;

    public  Vector3  dir;
    
    public  float start = -10;     
    public  float Y = 0;
    public  float lim = 1;
    public  float time = 0.5f;
    public  float add = 0.25f;
    
    private bool esp = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(start, Y, -1);
        dir.y = add;
        dir.x = add;
    }

    // Update is called once per frame
    void Update()
    {   
        
            if (transform.position.x < -start)
            {
                if(!esp)
                {
                    if (transform.position.y < Y-lim)
                    {
                        dir.y = add;
                        dir.x = add;
                    }
                    else if (transform.position.y > Y+lim)
                    {
                        dir.y = -add;
                        dir.x = add;
                    }
                StartCoroutine(EsperarSegundos(time));
                }
            }
            else
            {
                transform.position = new Vector3(start, Y , -1);
            }
    }

    IEnumerator EsperarSegundos(float segundos)
    {
        esp = true;
        yield return new WaitForSeconds(segundos);
        transform.Translate(dir, Space.World );
        esp = false;
    }



}