using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Score scoreScript;
    public float fallSpeed = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        scoreScript = GameObject.Find("Score").GetComponent<Score>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, -fallSpeed); 
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "missile")
    {
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
        if (scoreScript != null)
        {
            scoreScript.IncreaseScore();
        }
    }
}


}