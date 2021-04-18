using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMaster : MonoBehaviour
{
    public bool skipFlag;
    public bool resetFlag;

    // Start is called before the first frame update
    void Start()
    {
        skipFlag = false;
        resetFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetFlags()
    {
        skipFlag = false;
        resetFlag = false;
    }

    public void SkipButton()
    {
        skipFlag = true;
        Debug.Log("skip");
    }

    public void ResetButton()
    {
        resetFlag = true;
        Debug.Log("Reset");
    }
}
