using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour {

    public Text levelLabel;

	// Use this for initialization
	void Start () {
        levelLabel.text = "Level: 1";
	}
	
	// Update is called once per frame
	void Update () {
        if (Block.levelSuccess) {
            levelLabel.text = "Level:"+ControladorDeLeveis.level;
        }
	}
}
