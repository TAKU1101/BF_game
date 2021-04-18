using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMaster : MonoBehaviour
{
    public bool skipFlag;
    public bool resetFlag;
    public GameObject avator;

    // Start is called before the first frame update
    void Start()
    {
        skipFlag = false;
        resetFlag = false;
        Debug.Log(avator.transform.position.x);
        Debug.Log(avator.transform.position.y);
        Debug.Log(avator.transform.position.z);
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

    private void ResetGameBoard()
    {
        for (int i = 0; i < 500; i++)
        {
            if (StackData.stackObjs[i] != null)
                StackData.stackObjs[i].GetComponent<StackMaster>().counter = 0;
            StackData.stack[i] = 0;
        }
        if (avator.transform.localScale.x < 0)
            avator.transform.localScale = new Vector3(avator.transform.localScale.x * -1, avator.transform.localScale.y, avator.transform.localScale.z);
        avator.transform.position = new Vector3(-8.6f, 0.8f, 0f);
        StackData.adress = 0;
    }

    public void ResetButton()
    {
        skipFlag = true;
        resetFlag = true;
        ResetGameBoard();
        Debug.Log("Reset");
    }
}
