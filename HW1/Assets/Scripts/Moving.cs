using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private bool direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -0.5)
        {
            direction = false;
        }
        else if (transform.position.x <= -1)
        {
            direction = true;
        }

        if (direction)
        {
            transform.position += transform.right * Time.deltaTime * 0.25f;
        }
        else
        {
            transform.position -= transform.right * Time.deltaTime * 0.25f;
        }
    }
}
