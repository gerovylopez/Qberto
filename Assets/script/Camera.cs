using UnityEngine;

public class Camera : MonoBehaviour
{

    Vector3 playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if(playerPos.y > transform.position.y)
            transform.Translate(0, playerPos.y-transform.position.y,0);
    }
}
