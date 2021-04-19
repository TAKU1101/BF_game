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
                qText.text = "42文字未満で、メモリ0の値を42にしよう";
                break;
            case 2:
                qText.text = "文字列 Hi! を出力しよう";
                break;
            case 3:
                qText.text = "5文字以下でメモリ1-5の中身を出力しよう";
                break;
            case 4:
                qText.text = "42文字未満でメモリ0の中身をゼロにしよう";
                break;
            case 5:
                qText.text = "42文字未満でメモリ0の値をメモリ1に移動しよう(メモリ0の値は0にする)";
                break;
            case 6:
                qText.text = "42文字未満でメモリ0とメモリ1の合計値をメモリ0に入れよう";
                break;
            case 7:
                qText.text = "50文字未満でメモリ1に10, メモリ2に20, メモリ3に30, メモリ4に40, メモリ5に50を入れよう";
                break;
            case 8:
                qText.text = "42文字未満でメモリ0の最終的な値を変えずにメモリ0の値をメモリ1にコピーしよう";
                break;
            case 9:
                qText.text = "420文字未満でメモリ0とメモリ1の積をメモリ2に入れよう";
                break;
            case -1:
                qText.text = "BrainHackへようこそ\nあなたのコードによって猫が動くようになります。\n試しに「+」を入力してみましょう";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
