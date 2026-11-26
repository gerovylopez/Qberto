using UnityEditor.ShaderGraph;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{

    Vector3 playerPos;

    Color fondo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fondo = gameObject.GetComponentInChildren<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(fondo.r - transform.position.y,fondo.g - transform.position.y,fondo.b - transform.position.y);
        if (GameObject.FindGameObjectWithTag("Player"))
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        else
            playerPos = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        
        if(playerPos.y > transform.position.y)
            transform.Translate(0, playerPos.y-transform.position.y,0);
    }
}
