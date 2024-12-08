using UnityEngine;

public class Jumpap : MonoBehaviour
{
    public float doNay = 10f;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * doNay, ForceMode2D.Impulse);
        }
    }
}
