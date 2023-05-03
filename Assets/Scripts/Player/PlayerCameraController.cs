using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] Player player;

    private void Start()
    {

    }

    private void LateUpdate()
    {
        player.mainCamera.transform.position = new Vector3(transform.position.x,
                                                           transform.position.y,
                                                           player.mainCamera.transform.position.z);
    }
}
