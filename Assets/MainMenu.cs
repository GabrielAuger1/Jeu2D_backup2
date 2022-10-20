using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Cela permet d'acc�der au jeu via le menu principal
    public void JouerAuJeu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Cela permet de fermer la fen�tre du jeu
    public void QuitterLeJeu()
    {
        Debug.Log("QUITTER!");
        Application.Quit();
    }
}
