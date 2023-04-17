using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        //  配列の作成と初期化
        //  1 = player
        //  2 = object
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

        PrintArray();


        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //   playerの位置を取得
        int playerIndex = GetPlayerIndex();

       if(Input.GetKeyDown(KeyCode.RightArrow)) 
       {
            //  移動処理メソッド
            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        };

       if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
            //  移動処理メソッド
            MoveNumber(1, playerIndex, playerIndex - 1);

            PrintArray();
        }


    }

    //  配列の出力メソッド
    void PrintArray()
    {
        //  追加。文字列の宣言と初期化
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //  変更。文字列に結合していく
            debugText += map[i].ToString() + ",";

        }
        //  結合した文字列を出力
        Debug.Log(debugText);
    }

    //  playerの位置を取得するメソッド
    int GetPlayerIndex()
    {
        //  要素数はmap.Lengthで取得
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        //  失敗した場合、-1を返す
        return -1;
    }

    //  playerの移動メソッド
    bool MoveNumber(int number,int moveFrom,int moveTo) 
    {
        //  動けない条件を先に書く。早期リターン
        //  移動先が範囲外なら移動できない
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //  移動先に箱(2)がいたら
        if (map[moveTo] == 2) 
        {
            //  どの方向へ移動するか算出
            int velocity = moveTo - moveFrom;
            //  playerの移動先からさらに先へ箱を移動させる
            //  箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを呼び
            //  処理が再帰している。移動可不可をboolで記録
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            //  箱の移動が失敗したらplayerの移動も失敗
            if (!success) { return false; }
        }

        //  playerの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

}
