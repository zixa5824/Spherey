using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreLerpingEffect : MonoBehaviour
{
    Text myText;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float t = 0f;
    int len;
    private void Start()
    {
        lerpTime = 0.1f;
        myText = GetComponent<Text>();
        len = myColors.Length;
    }
    private void Update()
    {
        myText.color = Color.Lerp(myText.color, myColors[colorIndex], lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
