using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    public float velocidade;
    float centerScreen;

    float direcao = 0;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        ControladorDeLeveis.jogando = true;

        rb = GetComponent<Rigidbody2D>();
        centerScreen = Screen.currentResolution.width / 2;
	}
	
	// Update is called once per frame
	void Update () {

        direcao = 0;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > centerScreen)
            {
                direcao = 0.1f;
            }
            else if (touch.position.x < centerScreen)
            {
                direcao = -0.1f;
            }

        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            direcao = 0.1f;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            direcao = -0.1f;
        }

        float mover = direcao * velocidade * Time.deltaTime;
        transform.Translate(mover, 0.0f, 0.0f);


	}
}
