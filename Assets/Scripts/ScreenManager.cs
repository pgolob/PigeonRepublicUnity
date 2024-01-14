using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    public void startGame() {
        mainMenuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
    public void endGame() {
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}
