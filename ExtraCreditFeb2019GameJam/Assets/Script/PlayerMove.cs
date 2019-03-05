using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    public float speed;                             // lies, this is actually generated as acceleration for ball
    private Rigidbody2D rb;
    public float Fallmultiplier;                    // gravity with jump held
    public float LowFallmultiplier;                 // gravity with jump released
    public float jumpVelocity;                      // jump strength
    public Vector3 startingPosition;                // spawn location
    public bool thisDoesNothing = false;

    [Range(1, 10)]
    public float groundedSkin = 0.5f;
    public LayerMask mask;

    bool jumpRequest;                                           // allows for jump to happen or not
    List<Collider2D> groundedTouch = new List<Collider2D>();
    //bool grounded;

    Vector2 playerSize;
    // Vector2 boxSize;


    // void Awake()
    // {
        // playerSize = GetComponent<CapsuleCollider2D>().size;
        // boxSize = new Vector2(playerSize.x, groundedSkin);
    // }

    void Start()
    {
        audioManager = AudioManager.instance;               // instantiates AudioManager
        if (audioManager == null)
        {
            Debug.LogError("No AudioManager Found");
        }

        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // jump conditions
        if (Input.GetButtonDown("Jump") && groundedTouch.Count !=0) // && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            jumpRequest = true;
        }

        // jump velocity
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (Fallmultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowFallmultiplier - 1) * Time.deltaTime;
        }

        // restart conditions
        if (this.gameObject.transform.position.y <= -10)
        {
            Respawn();
        }
        if (this.gameObject.transform.position.y >= -10 && Input.GetKeyDown("r"))
        {
            Respawn();
            Debug.Log("response");
        }
    }

    public void Respawn()
    {
        this.gameObject.transform.position = startingPosition;
    }

    void FixedUpdate()
    {
        // move parameters
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rb.AddForce(movement * speed * Time.deltaTime);

        // fixed jump conditions
        if (jumpRequest)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            //grounded = false;
        }
        // else
        // {
            // Vector2 rayStart = (Vector2)transform.position + Vector2.down * playerSize.y * 0.5f;
            // grounded = Physics2D.Raycast (rayStart, Vector2.down, groundedSkin, mask);

            // Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y * boxSize.y) * 0.5f;
            // grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask) !=null);
        // }
    }

    // ground contact
    void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D[] points = new ContactPoint2D[2];
        col.GetContacts (points);
        for (int i = 0; i < points.Length; i++)
        {
            if(points [i].normal == Vector2.up && !groundedTouch.Contains(col.collider))
            {
                groundedTouch.Add(col.collider);
                return;
            }
        }
    }

    // ground release
    void OnCollisionExit2D(Collision2D col)
    {
        if (groundedTouch.Contains(col.collider))
        {
            groundedTouch.Remove(col.collider);
        }
    }
}