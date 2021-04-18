using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionMaster : MonoBehaviour
{
    public Text qText;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        switch (GM.GetComponent<InitStack>().stage)
        {
            case 1:
                qText.text = "メモリ0とメモリ1の合計値をメモリ0に入れよう";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
