using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy_v_beta : MonoBehaviour
{

    private SpriteRenderer sptrender;
    public  Sprite[] skins;

    public  Vector3  dir;
    
    public  float start = -15;     
    public  float Y = 0;
    public  float lim = 1;
    public  float time = 0.5f;
    public  float add = 0.25f;
    
    private bool esp = false;
    private int sk = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sptrender = GetComponent<SpriteRenderer>();
        Y = transform.position.y;
        start = transform.position.x;
        transform.position = new Vector3(start, Y, -1);
        if(start>0)
            GetComponent<SpriteRenderer>().flipX=true;
        dir.y = add;
        dir.x = add;
    }

    // Update is called once per frame
    void Update()
    {   

        if(!esp)
        {
            if (transform.position.y < Y-lim)
                dir.y = add;
            else if (transform.position.y > Y+lim)
                dir.y = -add;

            if (start<0 && transform.position.x < -start)
                dir.x = add;
            else if (start>0 && transform.position.x > -start)
                dir.x = -add;
            else
                transform.position = new Vector3(start, Y , -1);
            StartCoroutine(EsperarSegundos(time));
        }
        
    }

    IEnumerator EsperarSegundos(float segundos)
    {
        esp = true;
        yield return new WaitForSeconds(segundos);
        transform.Translate(dir, Space.World);

        if(skins.Length>(sk/2) && skins[(sk/2)])
        {
            sptrender.sprite = skins[(sk/2)];
            sk++;
            if ((sk/2)>3)
                sk=0;
        }       
        esp = false;
    }



}