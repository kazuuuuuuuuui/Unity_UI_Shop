using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemShopSelector : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    GameObject[] aaa;

    // Use this for initialization
    void Start()
    {
        //外でいじれたら嬉しい
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
        {"ひのきのぼう", 50},
        {"やくそう", 10},
        {"ふつうのたて", 20},
        {"すごそうなたて", 30},
        {"アイアンソード", 60},
           {"いのうえ", 5},
              {"ああああ", 15}
    };

        aaa = new GameObject[dict.Count];

        int counter = 0;
        foreach (KeyValuePair<string, int> pair in dict)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            obj.transform.SetParent(transform, false);
            obj.transform.position -= new Vector3(0, counter * 25, 0);

            GameObject namae = obj.transform.FindChild("名前").gameObject;
            namae.GetComponent<Text>().text = pair.Key;

            GameObject kingaku = obj.transform.FindChild("金額").gameObject;
            kingaku.GetComponent<Text>().text = pair.Value.ToString();

            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
