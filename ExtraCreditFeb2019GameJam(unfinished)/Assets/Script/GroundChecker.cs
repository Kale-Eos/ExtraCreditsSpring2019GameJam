using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;
    public float groundedSkin = 0.5f;
    public LayerMask mask;

    bool jumpRequest;
    bool grounded;

    Vector2 playerSize;
    Vector2 boxSize;

    void Awake()
    {
        playerSize = GetComponent<CapsuleCollider2D>().size;
    }

    void Update()
    {
        if(Input.GetButtonDown ("Jump") && grounded)
        {
            jumpRequest = true;
        }

        void FixedUpdate()
        {
            if (jumpRequest)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                jumpRequest = false;
                grounded = false;
            }
            else
            {
                Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
                grounded = (Physics2D.OverlapBox(boxCenter, boxSize, 0f, mask) != null);
            }
        }
    }
}
