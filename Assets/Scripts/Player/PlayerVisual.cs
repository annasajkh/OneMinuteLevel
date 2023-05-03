using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVisual : MonoBehaviour
{
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
