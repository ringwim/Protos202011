﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLog : MonoBehaviour
{
    public static ScrollLog instance;
    public Transform Content;
    public RectTransform trans;
    Text text;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 스크롤뷰 Content 자식으로 텍스트를 생성 (개행은 스페이스 두번으로 구분)
    /// </summary>
    /// <param name="_text">텍스트</param>
    public void Log(string _text)
    {
        int size = 1;
        char[] _c = _text.ToCharArray();
        for (int i = 0; i < _c.Length; i++)
        {
            if (_c[i] == ' ' && _c[i + 1] == ' ')
            {
                _c[i + 1] = '`';
                _c[i] = '\n';
            }
        }
        _text = string.Empty;
        for (int i = 0; i < _c.Length; i++)
        {
            if (_c[i] == '`')
            {
                size++;
                continue;
            }
            _text += _c[i].ToString();
        }
        text = Resources.Load<Text>("Text");
        Text go = Instantiate<Text>(text, Content);
        go.text = _text;
        go.fontSize = go.fontSize / size;
        ContentInit();
    }

    void ContentInit()
    {
        float height = 0f;
        for (int i = 0; i < Content.childCount; i++)
        {
            height += 68f;
        }
        trans.sizeDelta = new Vector2(280f, height);
    }
}
