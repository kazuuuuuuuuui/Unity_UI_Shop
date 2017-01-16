using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpriteBrinker : MonoBehaviour
{

    [SerializeField]
    float 点滅間隔;

    private Image img;

    IEnumerator Blink()
    {
        float alpha = img.color.a;

        while (true)
        {
            alpha *= (-1);
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            yield return new WaitForSeconds(点滅間隔);
        }
    }

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
        StartCoroutine("Blink");
    }
}
