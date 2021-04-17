using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class KeyMaster : MonoBehaviour
{
    public InputField playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        string text = playerInput.text;
        playerInput.Select();
        string parse = delSet(text, "+-[]<>.,");
        playerInput.text = parse;
    }
    
    private string delSet(string str, string set)
    {
        string  res = "";

        MatchCollection matche = Regex.Matches(str, @"[\-\[\]+.,<>]*");
        foreach (Match m in matche)
        {
            res += m.Value;
        }
        return (res);
    }

    public void endInput()
    {
        Debug.Log(playerInput.text);
        playerInput.text = "";
        playerInput.Select();
    }
}
