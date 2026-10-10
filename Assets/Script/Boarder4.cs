using UnityEngine;

public class Boarder4 : MonoBehaviour
{
    public HealthBar healthBar;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            healthBar.Damage();
            Destroy(collision.gameObject);
        }
    }
}
