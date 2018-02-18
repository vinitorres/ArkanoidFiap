using UnityEngine;

public class Block : MonoBehaviour {

    public static bool levelSuccess;

	// Use this for initialization
	void Start () {
        levelSuccess = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

        ControladorDeLeveis.CurrentBlocksCount -= 1;

        if (ControladorDeLeveis.CurrentBlocksCount == 0)
        {
            print("Level Completo");

            ControladorDeLeveis.level += 1;
            levelSuccess = true;

        }


        Destroy(gameObject);

    }
}
