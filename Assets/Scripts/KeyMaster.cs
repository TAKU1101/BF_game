using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class KeyMaster : MonoBehaviour
{
    public InputField playerInput;
    public Text outputText;

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

        MatchCollection matche = Regex.Matches(str, @"[\-\[\]+.<>]*");
        foreach (Match m in matche)
        {
            res += m.Value;
        }
        return (res);
    }

    public void endInput()
    {
        Debug.Log(playerInput.text);
        outputText.text = "";
        bfi(playerInput.text);
        playerInput.text = "";
        playerInput.Select();
    }

    private int loopStart(string code, int codeI)
    {
        int loopTime;

        codeI++;
        loopTime = 0;
        while (code[codeI] != ']' || loopTime > 0)
        {
            if (code[codeI] == '[')
                loopTime++;
            else if (code[codeI] == ']')
                loopTime--;
            codeI++;
            if (code[codeI] == '\0')
                return (codeI - 1);
        }
        return (codeI);
    }

    private int loopEnd(string code, int codeI)
    {
        int loopTime;

        codeI--;
        loopTime = 0;
        while (code[codeI] != '[' || loopTime > 0)
        {
            if (code[codeI] == ']')
                loopTime++;
            else if (code[codeI] == '[')
                loopTime--;
            codeI--;
            if (codeI < 0)
                return (0);
        }
        return (codeI);
    }

    private void bfi(string code)
    {
        for (int codeI = 0; codeI < code.Length; codeI++)
        {
            switch(code[codeI])
            {
                case '+':
                    StackData.stack[StackData.adress] += 1;
                    break;
                case '-':
                    StackData.stack[StackData.adress] -= 1;
                    break;
                case '>':
                    StackData.adress += 1;
                    break;
                case '<':
                    StackData.adress -= 1;
                    break;
                case '.':
                    // Debug.Log((char)StackData.stack[StackData.adress]);
                    outputText.text += (char)StackData.stack[StackData.adress];
                    break;
                case '[':
                    if (StackData.stack[StackData.adress] == 0)
                        codeI = loopStart(code, codeI);
                    break;
                case ']':
                    if (StackData.stack[StackData.adress] != 0)
                        codeI = loopEnd(code, codeI);
                    break;
            }
        }
    }
}
