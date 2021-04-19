using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMaster : MonoBehaviour
{
    public bool skipFlag;
    public bool resetFlag;
    public GameObject avator;
    public Text codeLen;

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
    }

    private void ResetGameBoard()
    {
        for (int i = 0; i < 24; i++)
        {
            StackData.stack[i] = StackData.initStack[i];
            if (StackData.stackObjs[i] != null)
                StackData.stackObjs[i].GetComponent<StackMaster>().counter = StackData.stack[i];
        }
        if (avator.transform.localScale.x < 0)
            avator.transform.localScale = new Vector3(avator.transform.localScale.x * -1, avator.transform.localScale.y, avator.transform.localScale.z);
        avator.transform.position = new Vector3(-8.6f, 0.8f, 0f);
        StackData.adress = 0;
    }

    public void ResetButton()
    {
        StackData.codeLen = 0;
        Debug.Log(codeLen);
        if (codeLen != null)
            codeLen.text = "codeLen: 0";
        skipFlag = true;
        resetFlag = true;
        ResetGameBoard();
    }
}
