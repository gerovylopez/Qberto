using UnityEngine;

public class hud : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject estamina;
    GameObject donas;
    GameObject caraHomero;
    playe_beta script_player;
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
         player = GameObject.FindGameObjectWithTag("Player");   
        }

        script_player =  player.GetComponent<playe_beta>();
    }

    // Update is called once per frame
    void Update()
    {
      if(script_player.staminf){
        estamina.transform.localScale = new Vector2(1, 0.4f);
        estamina.GetComponent<SpriteRenderer>().color = new Color(1,1,0);
      }
      else{
        estamina.transform.localScale = new Vector2(script_player.stamina/100, 0.4f);
        estamina.GetComponent<SpriteRenderer>().color = new Color(1,1,0.5F);
      }

    }
}
