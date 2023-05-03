using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    [SerializeField] private GameObject loseScreen;

    public void IsTryAgainPressed()
    {
        loseScreen.SetActive(false);
        Global.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
