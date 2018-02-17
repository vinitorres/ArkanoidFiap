using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public Button startButton;
    Button btn;

	// Use this for initialization
    void Start () {
        ControladorDeLeveis.jogando = false;
        btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartGame() {
        ControladorDeLeveis.level = 1;
        SceneManager.LoadScene("Main");
    }
}
