using UnityEngine;
using System.Collections;

public class FalliManagement : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // The prefab of the object to fall
    [SerializeField] float fallSpeed = 5f; // Speed of falling objects
    [SerializeField] float spawnInterval = 2f; // Time between spawns
    [SerializeField] float spawnRangeX = 5f; // Range of x-coordinates for spawning
    [SerializeField] float horizontalSpeed = 2f; // Speed of horizontal movement

    void Start()
    {
        StartCoroutine(SpawnFallingObjects());
    }

    IEnumerator SpawnFallingObjects()
    {
        while (true)
        {
            // Randomly determine spawn position
            Vector3 spawnPosition = new(
                Random.Range(-spawnRangeX, spawnRangeX), 
                             transform.position.y, 0f);

            // Instantiate the falling object
            GameObject fallingObject = Instantiate(fallingObjectPrefab, 
                                       spawnPosition, Quaternion.identity);

            // Start falling coroutine for the instantiated object
            StartCoroutine(Fall(fallingObject));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator Fall(GameObject obj)
    {
        while (obj != null && obj.transform.position.y > -10f) // Stop falling when below -10 y-coordinate
        {
            // Move diagonally
            obj.transform.Translate(new Vector3(-horizontalSpeed, -fallSpeed, 0) * Time.deltaTime);
            yield return null;
        }

        if (obj != null)
        {
            Destroy(obj); // Destroy the object when it falls below -10 y-coordinate
        }
    }
}
