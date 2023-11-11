using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool open = false;
    Vector3 DefPos,PostPos;
    void Start()
    {
        DefPos = transform.position;
        PostPos = new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.position = Vector3.Lerp(transform.position, PostPos, Time.deltaTime*2);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, DefPos, Time.deltaTime*2);
        }
    }
}
