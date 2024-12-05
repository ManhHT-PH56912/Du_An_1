using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float walkSpeed = 3f;

    Rigidbody2D rb;

    public enum WalkableDerection { Right, Left }

    private WalkableDerection _walkDerection;
    private Vector2 walkDerectionVector;

    public WalkableDerection walkDerection
    {
        get { return _walkDerection; }
        set
        {
            if (_walkDerection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDerection.Right)
                {
                    walkDerectionVector = Vector2.right;
                }
                else if (value == WalkableDerection.Left)
                {
                    walkDerectionVector = Vector2.left;
                }
            }

            _walkDerection = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(walkSpeed * Vector2.right.x, rb.linearVelocity.y);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}