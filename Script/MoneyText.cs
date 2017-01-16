using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyText : MonoBehaviour
{
    private Text hasMoney;

    // Use this for initialization
    void Start()
    {
        hasMoney = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hasMoney.text = PlayerStatus.money.ToString();
    }
}
