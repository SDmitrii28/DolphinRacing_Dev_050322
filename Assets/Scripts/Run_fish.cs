using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_fish : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velo = Vector2.left * speed;
        velo.y = rb.velocity.y;
        rb.velocity = velo;
        if (transform.position.x < -12.7f)
        {
            Destroy(gameObject);
        }
    }
}
