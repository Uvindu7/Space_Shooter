using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        rb.linearVelocity = new Vector2(0,7);
    }
    
      private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "uend")
        {
            Destroy(this.gameObject);
        }
    }
    
}
