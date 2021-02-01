using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;
    public Vector2 TrajectoryOrigin
    {
        get
        {
            return trajectoryOrigin;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);
        if (randomDirection < 1.0f)
        {
            Vector2 normalized = new Vector2(-xInitialForce, yRandomInitialForce).normalized * 50;
            rigidBody2D.AddForce(normalized);
        } else
        {
            Vector2 normalized = new Vector2(xInitialForce, yRandomInitialForce).normalized * 50;
            rigidBody2D.AddForce(normalized);
        }
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("PushBall", 2);
    }
}
