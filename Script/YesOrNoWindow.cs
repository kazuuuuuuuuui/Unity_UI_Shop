using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YesOrNoWindow : MonoBehaviour
{
    private int index;

    [SerializeField]
    Toggle[] toggles;

    [SerializeField]
    GameObject 店ウィンドウと金ウィンドウ;//消すのに不便だからがっちゃんこ

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
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                WindowManager.pi.Play();
                index = ++index % toggles.Length;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                WindowManager.pi.Play();
                index = (--index + toggles.Length) % toggles.Length;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                WindowManager.pi.Play();//鳴ってる?

                string str = toggles[index].GetComponentInChildren<Text>().text;
        
                if (str == "はい")
                {
                    MesseageWindow.message = "て「なにを　かうかね？";
                    MesseageWindow.メッセージ更新するかフラグ = true;
                    Destroy(WindowManager.今見ているウィンドウ);

                    GameObject obj = Instantiate(店ウィンドウと金ウィンドウ);
                    obj.transform.SetParent(transform.parent, false);

                    WindowManager.前に見てたウィンドウ = WindowManager.今見ているウィンドウ;
                    WindowManager.今見ているウィンドウ = obj;
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
