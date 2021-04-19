using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catpos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.position.x);
        if (this.transform.position.x > 10.0f)
        {
            Debug.Log("in 10 over");
            this.transform.position = new Vector3(-10.0f, -4.6f, 0.0f);
        }
    }
}
