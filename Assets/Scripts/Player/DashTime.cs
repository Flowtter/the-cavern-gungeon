using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashTime : MonoBehaviour
{
    public Image Dash;
    public float x;
    public RectTransform rt;
    void Start()
    {
        Dash = this.GetComponent<Image>();
        RectTransform rt = this.GetComponent<RectTransform>();
    }

    void Update()
    {

        x = (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeplacement>().ActualTime / GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeplacement>().Cooldown) * 0.5f;
        x = 0.5f - x;
        rt.sizeDelta = new Vector2(x, 0.05f);
    }
}

