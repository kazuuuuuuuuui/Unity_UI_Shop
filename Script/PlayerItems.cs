using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerItems : MonoBehaviour
{
    public static Text text;

    public static void HaveItemUpdate()
    {
        text.text = "";

        for (int i = 0; i < PlayerStatus.items.Count; i++)
        {
            Debug.Log(PlayerStatus.items[i]);
            text.text += PlayerStatus.items[i];
            text.text += "\n";
        }
    }

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

        HaveItemUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
