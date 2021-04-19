using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

public class KeyMaster : MonoBehaviour
{
    public InputField playerInput;
    public Text outputText;
    public GameObject avator;
    public GameObject button;
    public Text codeLen;

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
        button.GetComponent<ButtonMaster>().ResetFlags();
        bfi(playerInput.text);
        updateStack();
        StackData.codeLen += playerInput.text.Length;
        codeLen.text = "codeLen: " + StackData.codeLen.ToString();
        playerInput.text = "";
        playerInput.Select();
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

    private void updateStack()
    {
        for (int i = 0; i < 24; i++)
        {
            if (StackData.stackObjs[i] != null)
                StackData.stackObjs[i].GetComponent<StackMaster>().counter = StackData.stack[i];
        }
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

    private async void bfi(string code)
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
                    if (StackData.adress < 23)
                    {
                        StackData.adress += 1;
                        adressIncAnimation();
                    }
                    break;
                case '<':
                    if (StackData.adress > 0)
                    {
                        StackData.adress -= 1;
                        adressDecAnimation();
                    }
                    break;
                case '.':
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
            if (button.GetComponent<ButtonMaster>().skipFlag == false)
                await Task.Delay(250);
            updateStack();
        }
        if (button.GetComponent<ButtonMaster>().resetFlag == true)
            ResetGameBoard();
        isCrear();
    }

    private void isCrear()
    {
        switch (button.GetComponent<InitStack>().stage)
        {
            case 1:
                if (StackData.stack[0] == 42 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 2:
                if (string.Compare("Hi!", outputText.text) == 0)
                    SceneManager.LoadScene("Result");
                break;
            case 3:
                if (string.Compare("Hello!", outputText.text) == 0 && StackData.codeLen <= 5)
                    SceneManager.LoadScene("Result");
                break;
            case 4:
                if (StackData.stack[0] == 0 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 5:
                if (StackData.stack[0] == 0 && StackData.stack[1] == 42 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 6:
                if (StackData.stack[0] == 99 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 7:
                if (StackData.stack[1] == 10 && StackData.stack[2] == 20 && StackData.stack[3] == 30 && StackData.stack[4] == 40 && StackData.stack[5] == 50 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 8:
                if (StackData.stack[0] == 42 && StackData.stack[1] == 42 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
            case 9:
                if (StackData.stack[2] == 420 && StackData.codeLen < 42)
                    SceneManager.LoadScene("Result");
                break;
        }
    }

    private async void adressIncAnimation()
    {
        if (avator.transform.localScale.x < 0)
            avator.transform.localScale = new Vector3(avator.transform.localScale.x * -1, avator.transform.localScale.y, avator.transform.localScale.z);
        for (float i = 1; i <= 100; i++)
        {
            avator.transform.position = new Vector3(avator.transform.position.x + 0.0075f, avator.transform.position.y, avator.transform.position.z);
            if (button.GetComponent<ButtonMaster>().skipFlag == false)
                await Task.Delay(1);
        }
    }

    private async void adressDecAnimation()
    {
        if (avator.transform.localScale.x > 0)
            avator.transform.localScale = new Vector3(avator.transform.localScale.x * -1, avator.transform.localScale.y, avator.transform.localScale.z);
        for (float i = 1; i <= 100; i++)
        {
            avator.transform.position = new Vector3(avator.transform.position.x - 0.0075f, avator.transform.position.y, avator.transform.position.z);
            if (button.GetComponent<ButtonMaster>().skipFlag == false)
                await Task.Delay(1);
        }
    }
}
