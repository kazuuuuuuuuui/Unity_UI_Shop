using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static int money;
    public static string[] items;

    // Use this for initialization
    void Start()
    {
        money = 50;
        items = new string[]{
            "どうのつるぎ",
            "どうのたて",
            "やくそう",
        };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
