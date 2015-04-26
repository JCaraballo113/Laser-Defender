using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoText
{
    private float _writeSpeed  = 0f;
    private float _timer = 0f;
    private string _text = "";
    private int _letterCount = 0;
    private Text UIText;
    private bool _hasFinished = false;

    public AutoText(float writeSpeed, string toWrite, Text uIText)
    {
        UIText = uIText;
        _writeSpeed = writeSpeed;
        _text = toWrite;
    }

    public void AutoWrite()
    {
        if (_letterCount != _text.Length)
        {
            _timer += Time.deltaTime;
            if (_timer > _writeSpeed)
            {
                UIText.text += _text[_letterCount];
                _letterCount++;
                _timer = 0;
            }
        }
        else
        {
            DoneWriting();
        }
        
    }

    public bool HasFinishedWrite()
    {
        return _hasFinished;
    }

    private void DoneWriting()
    {
        _hasFinished = true;
    }

}
