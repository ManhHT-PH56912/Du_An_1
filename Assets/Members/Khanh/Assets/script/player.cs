using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour
{
    public float dichuyen;
    public float tocdo;
    public int doCao;
    public bool duocPhepNhay;

    private Rigidbody2D rb;
    private float h_move;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dichuyen = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            dichuyen = 1;
        }
        else dichuyen = 0;

        transform.Translate(Vector3.right * tocdo * dichuyen*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && duocPhepNhay)
        { 
           rb.AddForce(Vector2.up*doCao,ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitboxkhac)
    {
        if(hitboxkhac.gameObject.tag == "ground")
        {
            duocPhepNhay = true;
        }
    }
    private void OnTriggerExit2D(Collider2D hitboxkhac)
    {
        if (hitboxkhac.gameObject.tag == "ground")
        {
            duocPhepNhay = false;
        }
    }
}
