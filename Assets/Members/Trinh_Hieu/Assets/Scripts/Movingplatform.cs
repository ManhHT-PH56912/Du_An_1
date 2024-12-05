using UnityEngine;

public class Movingplatform : MonoBehaviour
{
    public int tocDoDiChuyen = 1;
    public Transform start;
    public Transform end;
    public Vector2 mucTieu;
    
    void Start()
    {
        mucTieu = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, start.position) < 0.1f)
        {
            mucTieu = end.position;
        }
        if (Vector2.Distance(transform.position, end.position) < 0.1f)
        {
            mucTieu = start.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, mucTieu, tocDoDiChuyen * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
