using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMaster : MonoBehaviour
{
    public GameObject catPref;

    // Start is called before the first frame update
    void Start()
    {
        GameObject catObj = Instantiate(catPref, this.transform);
        Rigidbody rb = catObj.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(1.0f, 0.0f, 0.0f);
        catObj.transform.position = new Vector3(-10.0f, -4.6f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
