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
        //  �z��̍쐬�Ə�����
        //  1 = player
        //  2 = object
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };

        PrintArray();


        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //   player�̈ʒu���擾
        int playerIndex = GetPlayerIndex();

       if(Input.GetKeyDown(KeyCode.RightArrow)) 
       {
            //  �ړ��������\�b�h
            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        };

       if(Input.GetKeyDown(KeyCode.LeftArrow))
       {
            //  �ړ��������\�b�h
            MoveNumber(1, playerIndex, playerIndex - 1);

            PrintArray();
        }


    }

    //  �z��̏o�̓��\�b�h
    void PrintArray()
    {
        //  �ǉ��B������̐錾�Ə�����
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //  �ύX�B������Ɍ������Ă���
            debugText += map[i].ToString() + ",";

        }
        //  ����������������o��
        Debug.Log(debugText);
    }

    //  player�̈ʒu���擾���郁�\�b�h
    int GetPlayerIndex()
    {
        //  �v�f����map.Length�Ŏ擾
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        //  ���s�����ꍇ�A-1��Ԃ�
        return -1;
    }

    //  player�̈ړ����\�b�h
    bool MoveNumber(int number,int moveFrom,int moveTo) 
    {
        //  �����Ȃ��������ɏ����B�������^�[��
        //  �ړ��悪�͈͊O�Ȃ�ړ��ł��Ȃ�
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //  �ړ���ɔ�(2)��������
        if (map[moveTo] == 2) 
        {
            //  �ǂ̕����ֈړ����邩�Z�o
            int velocity = moveTo - moveFrom;
            //  player�̈ړ��悩�炳��ɐ�֔����ړ�������
            //  ���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h���Ă�
            //  �������ċA���Ă���B�ړ��s��bool�ŋL�^
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            //  ���̈ړ������s������player�̈ړ������s
            if (!success) { return false; }
        }

        //  player�̈ړ�����
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

}
