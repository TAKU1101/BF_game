using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackMaster : MonoBehaviour
{
    public Text counterText;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = counter.ToString();
    }
}
