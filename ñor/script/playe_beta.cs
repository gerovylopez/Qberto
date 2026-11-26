using UnityEngine;

public class playe_beta : MonoBehaviour
{

    public Vector2  dir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.D)){
                dir.y = -0.4082484f*3;
                dir.x = 0.7071072f;
            }
            else if (Input.GetKeyDown(KeyCode.A)){
                dir.y = 0.4082484f*3;
                dir.x = -0.7071072f;
            }
            else if (Input.GetKeyDown(KeyCode.W) ){
                dir.y = 0.4082484f*3;
                dir.x = -0.7071072f*2;
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                dir.y = -0.4082484f*3;
                dir.x = 0.7071072f*2;
            }
            else{
                dir.y = 0;
                dir.x = 0;
            }

       Vector2 move = new Vector2(dir.x, dir.y);
       transform.Translate(move);
    }
    

    
}