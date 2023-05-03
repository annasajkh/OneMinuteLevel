using UnityEngine;

public enum HoldType
{
    None,
    Sword,
    Gun
}

public class Global : MonoBehaviour
{
    public static Sprite sword;
    public static Sprite gun;
    public static Bullet bullet;
    public static int killsCount = 0;
    public static int time = 60;
    public static bool isAlreadyTutorial = false;

    public void Start()
    {

        sword = Resources.Load<Sprite>("Sprites/Items/sword");
        gun = Resources.Load<Sprite>("Sprites/Items/gun");
        bullet = Resources.Load<Bullet>("Prefabs/Bullet");
    }

    public static void ResetGame()
    {
        Time.timeScale = 1;
        killsCount = 0;
        time = 60;
    }

}
