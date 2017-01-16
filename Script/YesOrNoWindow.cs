using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YesOrNoWindow : MonoBehaviour
{
    private int index;

    [SerializeField]
    Toggle[] toggles;

    // Use this for initialization
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        toggles[index].isOn = true;

        if (WindowManager.今見ているウィンドウ.name == this.name)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow)) index = ++index % toggles.Length;
            else if (Input.GetKeyDown(KeyCode.UpArrow)) index = (--index + toggles.Length) % toggles.Length;
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                string str = toggles[index].GetComponentInChildren<Text>().text;
                Debug.Log(str);

                if (str == "はい")
                {

                }
                else if (str == "いいえ")
                {
                    MesseageWindow.message = "て「また　きてね！";
                    MesseageWindow.メッセージ更新するかフラグ = true;
                }
            }
        }
    }
}
