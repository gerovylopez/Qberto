using System;
using System.Collections;
using System.Runtime.ExceptionServices;
using Unity.Android.Gradle;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class fabricgame : MonoBehaviour
{


    public GameObject Casilla;
    public GameObject Finish;
    public GameObject Player;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject EnemyV;
    public GameObject Donut;
    public GameObject Beer;
    public GameObject Armor;
    public GameObject Checkpoint;
    public  float X = (float)Math.Sqrt(2)/2;     
    public  float Y = (float)(Math.Sqrt(2)*Math.Tan(30*Mathf.Deg2Rad))/2; //tan(pi/6)*2^0.5)*1.5
    //float Z = (float)Math.Tan(30*Mathf.Deg2Rad))/2;
    public int cantidadfilas = 10;
    public GameObject Camara;
   

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
        int i = 0;
        int j = 0;
        while( i < cantidadfilas)
        {
            if(i<20)
                j=-i;
            else
                j=-20;
            Instantiate(Finish, new Vector3((j-1)*X*1, -i*3*Y, 0), Quaternion.identity);
            while(j < i && j < 21)
            {
                if (i%2==0&& math.abs(j%2)==1)
                    if ( math.abs(j%2)==Random.Range(0,20)%2)
                        Instantiate(Finish, new Vector3(j*X*1, -i*3*Y, 0), Quaternion.identity);
                    else
                        Instantiate(Casilla, new Vector3(j*X*1, -i*3*Y, 0), Quaternion.identity);
                else if(i%2==1&&j%2==0)
                    Instantiate(Casilla, new Vector3(j*X*1, -i*3*Y, 0), Quaternion.identity);
            j++;
            }
            Instantiate(Finish, new Vector3((j+1)*X*1, -i*3*Y, 0), Quaternion.identity);
            i++;
        }
        if(i<20)
            j=-i;
        else
            j=-20;
        Instantiate(Finish, new Vector3((j-1)*X*1, -i*3*Y, 0), Quaternion.identity);
        while(j < i && j < 21)
        {
            if (i%2==0&& math.abs(j%2)==1)
                Instantiate(Finish, new Vector3(j*X*1, -i*3*Y, 0), Quaternion.identity);
            else if(i%2==1&&j%2==0)
                Instantiate(Finish, new Vector3(j*X*1, -i*3*Y, 0), Quaternion.identity);
            j++;
        }
        Instantiate(Finish, new Vector3((j+1)*X*1, -i*3*Y, 0), Quaternion.identity);
        j--;
        Instantiate(Player, new Vector3((j-2)*X+X, -(i-2)*3*Y, -1), Quaternion.identity);
        //Camara = GameObject.FindGameObjectWithTag("Camera");
        Camara.transform.position = new Vector3(0,  -(i-8)*3*Y, -3);
    }
    bool donut = true;
    public  int sec = 10;
    // Update is called once per frame
    void Update()
    {          
        if (donut)
            StartCoroutine(MonedaCadaXSeg(sec));
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < cantidadfilas/20){
            Vector2 Cass = randomCass();
            Instantiate(Enemy1, new Vector3(Cass.x, Cass.y + Y, -1), Quaternion.identity);
        }
        
        if(GameObject.FindGameObjectsWithTag("Checkpoint").Length < cantidadfilas/20 +1){
            Vector2 Cass = randomCass();
            Instantiate(Checkpoint, new Vector3(Cass.x, Cass.y + Y, -1), Quaternion.identity);
            Debug.Log("miua");
        }
    }
    IEnumerator MonedaCadaXSeg(float segundos)
    {
        donut = false;
        yield return new WaitForSeconds(segundos);
        
        Instantiate(Donut, randomCass(), Quaternion.identity);
        
        donut = true;

    }
    Vector3 randomCass()
    {
        GameObject[] casillas = GameObject.FindGameObjectsWithTag("Casilla");
        int RNX = Random.Range(0,casillas.Length);
        //if (casillas[i])
           // Debug.Log(casillas[i].transform.position + "Casilla nº" + i);

        return new Vector3(casillas[RNX].transform.position.x, casillas[RNX].transform.position.y + 2*Y, -2);
    }


}