using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour
{
    [SerializeField]
    GameObject commandWindow;

    [SerializeField]
    GameObject messeageWindow;

    [SerializeField]
    GameObject yesnoWindow;

    public static GameObject 今見ているウィンドウ;
    public static GameObject 前に見てたウィンドウ;

    public static AudioSource pi;


    // Use this for initialization
    void Start()
    {
        pi = gameObject.GetComponent<AudioSource>();

        今見ているウィンドウ = null;
        前に見てたウィンドウ = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(今見ているウィンドウ);

        if (Input.GetKeyDown(KeyCode.B) && 今見ているウィンドウ != null)
        {
            Destroy(今見ているウィンドウ);
            今見ているウィンドウ = 前に見てたウィンドウ;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (今見ているウィンドウ == null)
            {
                pi.Play();
                GameObject obj = Instantiate(commandWindow);
                obj.transform.SetParent(transform, false);
                前に見てたウィンドウ = 今見ているウィンドウ;
                今見ているウィンドウ = obj;
            }
            else if (今見ているウィンドウ.name == "コマンド(Clone)")
            {
                pi.Play();
                MesseageWindow.message = "て「ここは　ぶきと　ぼうぐのみせだ。\n　 うっているものを みるかね？";
                GameObject obj = Instantiate(messeageWindow);
                obj.transform.SetParent(transform, false);

                GameObject obj2 = Instantiate(yesnoWindow);//雑に
                obj2.transform.SetParent(transform, false);
                前に見てたウィンドウ = 今見ているウィンドウ;
                今見ているウィンドウ = obj2;
            }
        }
    }
}
