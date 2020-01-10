using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPos : MonoBehaviour
{
    public Vector3 init;
    void Start()
    {
        init = new Vector3(Mathf.RoundToInt( transform.position.x), Mathf.RoundToInt( transform.position.y), 0);
        transform.position = init;
    }

}
