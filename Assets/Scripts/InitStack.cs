using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStack : MonoBehaviour
{
    public GameObject stackPrefab;
    public GameObject stacksObj;
    public int stage;

    void Awake()
    {
        switch (stage)
        {
            case 1:
                StackData.initStack = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 2:
                StackData.initStack = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 3:
                StackData.initStack = new int[] { 72, 101, 108, 108, 111, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 4:
                StackData.initStack = new int[] { 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 5:
                StackData.initStack = new int[] { 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 6:
                StackData.initStack = new int[] { 42, 57, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 7:
                StackData.initStack = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 8:
                StackData.initStack = new int[] { 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 9:
                StackData.initStack = new int[] { 42, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
        }
        int[] stack = StackData.stack;
        for (int i = 0; i < 24; i++)
        {
            GameObject g = Instantiate(stackPrefab, stacksObj.transform);
            g.transform.position = new Vector3(i * 40f - 450f + 480f, 0f + 265.5f, 0f);
            g.GetComponent<StackMaster>().index = i;
            stack[i] = StackData.initStack[i];
            g.GetComponent<StackMaster>().counter = stack[i];
            StackData.stackObjs[i] = g;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
