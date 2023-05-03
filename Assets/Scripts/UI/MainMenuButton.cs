using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void IsMainMenuButtonPressed()
    {
        Global.ResetGame();
        SceneManager.LoadScene(0);
    }

}
