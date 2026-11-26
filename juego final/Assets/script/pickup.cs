using UnityEngine;

    public class Pickup : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 camara = GameObject.FindGameObjectWithTag("Camera").transform.position;
            if(transform.position.y< camara.y -10)
                Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("hi");
            if (collision.CompareTag("Player"))
                Destroy(gameObject);
        }
    
}
