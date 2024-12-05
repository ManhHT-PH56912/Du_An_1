using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D checkpointCollder;
    private void Awake()
    {
        checkpointCollder = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player")) 
        {
            respawn.RespawnPoint = this.gameObject;
            checkpointCollder.enabled = false;
        }
    }
         
}
