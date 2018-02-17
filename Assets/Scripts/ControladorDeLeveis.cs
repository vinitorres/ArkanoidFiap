using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeLeveis : MonoBehaviour {

    public GameObject blockPreFab;
    public static bool jogando;
    public static int CurrentBlocksCount;
    public static int level = 1;

    float minX = -3.1f, maxX = 3.1f;
    float minY = 2, maxY = 7.2f;

    public Sprite[] blockColorList;

    SpriteRenderer sr;

	// Use this for initialization
    void Start () {
        LoadBlocks();
	}

    // Update is called once per frame
    void Update()
    {
        if (Block.levelSuccess) {
            print("LoadBlocks IF");
            Ball.velocidade = Ball.velocidade + 10.0f;
            LoadBlocks();
        }
	}

    public void LoadBlocks() {
        int count = 1;

        CurrentBlocksCount = level;

        while (count <= level)
        {

            Vector3 positionBlock = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 1);

            Instantiate(blockPreFab, positionBlock, transform.rotation);

            sr = blockPreFab.GetComponent<SpriteRenderer>();

            sr.sprite = blockColorList[Random.Range(0, blockColorList.Length)];

            print("Passou aqui");
            count = count + 1;
        }

    }
}
