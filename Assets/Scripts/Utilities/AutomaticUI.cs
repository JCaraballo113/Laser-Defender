using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AutomaticUI : MonoBehaviour
{
    public float WriteSpeed = 0.2f;
    public Text[] ToggableTexts;
    public float ToggleSpeed = 0.3f;
    public bool HasScore = false;

    private Text _autoTextElement;
    private AutoText _autoText;
    private float _timer = 0f;
    private short _toggleCount = 0;


    void Start()
    {

        if (ToggableTexts != null)
        {
            foreach (Text toggableText in ToggableTexts)
            {
                toggableText.enabled = false;
            }
        }

        _autoTextElement = gameObject.GetComponent<Text>();
        string desiredText = _autoTextElement.text;
        _autoTextElement.text = "";
        if (HasScore)
        {
            _autoText = new AutoText(WriteSpeed, desiredText + " " + GameManager.GetScore(), _autoTextElement);
        }
        else
        {
            _autoText = new AutoText(WriteSpeed, desiredText, _autoTextElement);
        }


    }

    void Update()
    {
            if (!_autoText.HasFinishedWrite())
            {
                _autoText.AutoWrite();
            }
            else if (ToggableTexts != null)
            {
                ToggleTexts();
            }  
        
        
    }

    void ToggleTexts()
    {
        if (_toggleCount != ToggableTexts.Length)
        {
            _timer += Time.deltaTime;

            if (_timer > ToggleSpeed)
            {
                ToggableTexts[_toggleCount].enabled = true;
                _toggleCount++;
                _timer = 0f;
            }
        }
    }
}
