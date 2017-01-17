using UnityEngine;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    public static int money;
    public static List<string> items = new List<string>();

    //public static string[] items;

    // Use this for initialization
    void Awake()
    {
        money = 1000;
        items.Add("どうのつるぎ");
        items.Add("たびびとのふく");    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
