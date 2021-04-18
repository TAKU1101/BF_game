using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStack : MonoBehaviour
{
    public GameObject stackPrefab;
    public GameObject stacksObj;

    void Awake()
    {
        int[] stack = StackData.stack;
        for (int i = 0; i < 500; i++)
        {
            GameObject g = Instantiate(stackPrefab, stacksObj.transform);
            g.transform.position = new Vector3(i * 40f - 450f + 480f, 0f + 265.5f, 0f);
            g.GetComponent<StackMaster>().index = i;
            stack[i] = 0;
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
