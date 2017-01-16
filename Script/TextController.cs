using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour
{

    private string str;
    public float 文字出力の間隔;
    private Text text;

    private IEnumerator TextUpdate()
    {
        for (int i = 0; i < str.Length; i++)
        {
            yield return new WaitForSeconds(文字出力の間隔);
            text.text += str[i];
        }
    }

    void Start()
    {
        text = GetComponent<Text>();
        str = text.text;
        text.text = "";
        StartCoroutine("TextUpdate");
    }
}
