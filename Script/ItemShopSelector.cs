using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemShopSelector : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    private Toggle[] toggles;

    private int index;

    // Use this for initialization
    void Start()
    {
        index = 0;

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

        toggles = new Toggle[dict.Count];

        int counter = 0;
        foreach (KeyValuePair<string, int> pair in dict)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            obj.transform.SetParent(transform, false);
            obj.transform.position -= new Vector3(0, counter * 25, 0);

            GameObject name = obj.transform.FindChild("名前").gameObject;
            name.GetComponent<Text>().text = pair.Key;

            GameObject price = obj.transform.FindChild("金額").gameObject;
            price.GetComponent<Text>().text = pair.Value.ToString();

            obj.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();//トグルグループに登録してる
            toggles[counter] = obj.GetComponent<Toggle>();

            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) index = ++index % toggles.Length;
        else if (Input.GetKeyDown(KeyCode.UpArrow)) index = (--index + toggles.Length) % toggles.Length;
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject selectedItem = toggles[index].transform.FindChild("金額").gameObject;
            int price = int.Parse(selectedItem.GetComponent<Text>().text);
            if (PlayerStatus.money > price) PlayerStatus.money -= price;
        }

        toggles[index].isOn = true;
    }
}
