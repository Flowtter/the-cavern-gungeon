using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShine : MonoBehaviour
{
    public float x;
    public SpriteRenderer sr;
    Color co;
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        x = (GetComponent<PlayerDeplacement>().ActualTime / GetComponent<PlayerDeplacement>().Cooldown);
        sr.color = new Color(1,1-x, 1, 1f);
    }
}
