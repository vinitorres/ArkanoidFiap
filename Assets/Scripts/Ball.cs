using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public static float velocidade;
    bool ballMoving;

    float directionX, directionY;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        ballMoving = false;
        velocidade = 400;
	}

    // Update is called once per frame
    void Update()
    {

        if (ControladorDeLeveis.jogando)
        {
            if (Input.GetButtonDown("Fire1") && !ballMoving)
            {
                ballMoving = true;
                rb.velocity = Vector2.up * velocidade * Time.deltaTime;
            }
        }
    

    }

    void OnCollisionEnter2D(Collision2D col)
    {
    
        // Hit the Racket?
        if (col.gameObject.tag == "Player")
        {

            directionX = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            directionY = 1;
            Vector2 dir = new Vector2(directionX, directionY).normalized;

            rb.velocity = dir * velocidade * Time.deltaTime;
        }

        if (col.gameObject.tag == "Wall") {

            directionX = directionX * -1;

            Vector2 dir = new Vector2(directionX, directionY).normalized;

            rb.velocity = dir * velocidade * Time.deltaTime;
        }

        if (col.gameObject.tag == "Block") {

            Vector3 colliderCenter = col.collider.bounds.center;

            float colliderHeight = col.collider.bounds.size.y / 2;

            if (transform.position.y < colliderCenter.y - colliderHeight) {
                directionY = -1;
            } else if (transform.position.y > colliderCenter.y + colliderHeight) {
                directionY = 1;
            }

            float colliderSizeAfterCenter = col.collider.bounds.size.x/2;

            if (transform.position.x > colliderCenter.x + colliderSizeAfterCenter || transform.position.x < colliderCenter.x - colliderSizeAfterCenter) {
                directionX = directionX * -1;
            }

            Vector2 dir = new Vector2(directionX, directionY);

            rb.velocity = dir * velocidade * Time.deltaTime;


        }

        if (col.gameObject.tag == "Top Wall") {
            directionY = -1;
        } 

        if (col.gameObject.tag == "Ground")
        {
            ControladorDeLeveis.jogando = false;
            ballMoving = false;
            SceneManager.LoadScene("StartGame");

        }
    }

    float hitFactor(Vector2 ballPos, Vector2 playerPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - playerPos.x) / racketWidth;
    }
}
