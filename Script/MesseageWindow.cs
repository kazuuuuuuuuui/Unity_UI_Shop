using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MesseageWindow : MonoBehaviour
{
    AudioSource pipipipi;

    private Text text;
    public static bool メッセージ更新するかフラグ;
    public static string message;
    public float 文字出力の間隔;

    private IEnumerator TextUpdate()
    {
        //びみょい
        メッセージ更新するかフラグ = false;
        text.text = "";//メッセージ初期化しちゃう

        for (int i = 0; i < message.Length; i++)
        {
            yield return new WaitForSeconds(文字出力の間隔);
            text.text += message[i];
        }
    }

    void Start()
    {
        pipipipi = GetComponent<AudioSource>();

        メッセージ更新するかフラグ = true;
        text = GetComponent<Text>();
        //StartCoroutine("TextUpdate");
    }

    void Update()
    {
        if (メッセージ更新するかフラグ) StartCoroutine("TextUpdate");
    }
}
