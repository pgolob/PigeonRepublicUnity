using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void die() {
        SceneManager.LoadScene(2);
    }

    public void backToMenu() {
        SceneManager.LoadScene(0);
    }
    public void restart() {
        SceneManager.LoadScene(1);
    }
}
