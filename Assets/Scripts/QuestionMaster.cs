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
                qText.text = "BrainHackへようこそ\nここでは、あなたのコードによって猫が動きます。\n試しに「+」を入力してみましょう";
                break;
            case -2:
                qText.text = "「+」を入力することで猫がいる位置の値を1増やしてくれます。\n逆に「-」を入力すると1減らしてくれます\nでは、「-」を入力してみましょう";
                break;
            case -3:
                qText.text = "次に、「>」と「<」についてです。\nこの文字を入力すると猫が左右に動いてくれます。\n「+>+>+<+<+」と入力してみましょう";
                break;
            case -4:
                qText.text = "次に繰り返しについてです。\n「[」この文字を入力すると猫のいる位置が0でなければ、\n対応する「]」までコードを進めてくれます\n「>+++[<+++>-]」を入力してみましょう";
                break;
            case -5:
                qText.text = "「[」と「]」を使うことで、コードを短縮を短縮したり、\n条件を付けて実行できます積極的に使いましょう\n最後に「.」を使ってみましょう\n試しに「.」を入力してみましょう";
                break;
            case -6:
                qText.text = "A\n上にAが出力されました、\nこれは数字の65が文字のAと対応付けられているためです。\nこれで、すべて説明し終わりました。遊んでみましょう!\nメモリ5に1を入れるとタイトルに戻ります。"
                    ;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
