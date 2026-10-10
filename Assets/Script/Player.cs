using UnityEngine;


public class Player : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    private float speed = 3;
    private Rigidbody2D rb;
    public GameObject missile;
    public GameObject firelocation;
    public HealthBar healthBar;
    public AudioSource audioSource;
    public AudioClip shootSound;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        float h=fixedJoystick.Horizontal;
        rb.linearVelocity = new Vector2(h*speed,0);

    }

    public void Fire()
    {
    Instantiate(missile, firelocation.transform.position, Quaternion.identity);
    audioSource.clip = shootSound;
    audioSource.Play();
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            healthBar.Damage();
            Destroy(collision.gameObject);
        }
    }
        
    

}
