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
        {"ひのきのぼう", 5},
        {"こんぼう", 10},
        {"どうのつるぎ", 100},
        {"ぬののふく", 30},
        {"たびびとのふく", 70},
        {"かわのよろい", 150},
        {"ドラゴンシールド", 3500}
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
            WindowManager.pi.Play();

            GameObject selectedItemPrice = toggles[index].transform.FindChild("金額").gameObject;
            int price = int.Parse(selectedItemPrice.GetComponent<Text>().text);
            if (PlayerStatus.money > price)
            {
                GameObject selectedItemName = toggles[index].transform.FindChild("名前").gameObject;
                MesseageWindow.message = "て「" + selectedItemName.GetComponent<Text>().text + "だね\n　 どうも ありがとう。";
                MesseageWindow.メッセージ更新するかフラグ = true;
                PlayerStatus.money -= price;
                PlayerStatus.items.Add(selectedItemName.GetComponent<Text>().text);
                PlayerItems.HaveItemUpdate();
            }
            else
            {
                MesseageWindow.message = "て「おかねが　たりないよ！";
                MesseageWindow.メッセージ更新するかフラグ = true;
            }
        }

        toggles[index].isOn = true;
    }
}
