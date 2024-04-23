using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //setings
    [SerializeField] GameObject _dropdown;
    TMP_Dropdown _language;
    [SerializeField] Slider _saingDelay;
    //language
    [SerializeField] GameObject[] _elemetsUI;
    [SerializeField] string[] _englishText;
    [SerializeField] string[] _russianText;
    [SerializeField] TextMeshProUGUI[] _texts;
    [SerializeField] Vector2[] _elemetsPosRus;
    [SerializeField] Vector2[] _elemetsPosEng;
    
    [SerializeField] GameObject[] _cameras;
    [SerializeField] GameObject[] _canvases;
    

    private void Start()
    {
        _language = _dropdown.GetComponent<TMP_Dropdown>();
        LoadSetings();
    }

    public void OnClickTestRoom()
    {
        SceneManager.LoadScene("TestRoom");
    }
    public void OnClickSetings()
    {
        _cameras[0].SetActive(false);
        _cameras[1].SetActive(true);
        _canvases[0].SetActive(false);
        _canvases[1].SetActive(true);
    }
    public void OnClickBackFromSetings()
    {
        _cameras[0].SetActive(true);
        _cameras[1].SetActive(false);
        _canvases[0].SetActive(true);
        _canvases[1].SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ApplySetings()
    {
        //apply language
        string[] language = _russianText;
        Vector2[] pos =_elemetsPosRus;
        if (_language.value == 0)
        {
            language = _russianText;
            pos = _elemetsPosRus;
            PlayerPrefs.SetString("language", "Rus");
        }
        else
        {
            if (_language.value == 1)
            {
                language = _englishText;
                pos = _elemetsPosEng;
                PlayerPrefs.SetString("language", "Eng");
            }
        }
        Debug.Log("Set language " + _language.options[_language.value].text);
        for(int i = 0;i < _texts.Length; i++)
        {
            _texts[i].text = language[i];
        }
        for(int i = 0;i < _elemetsUI.Length; i++)
        {
            Debug.Log("pos UI element " + i + " = " + _elemetsUI[i].transform.position);
            _elemetsUI[i].transform.position = pos[i];
        }
        Debug.Log("Set language completed");
        //apply text display speed
        PlayerPrefs.SetFloat("SaingDlay", _saingDelay.value);
        Debug.Log("Set _saingDelay " + _saingDelay.value);
    }
    public void LoadSetings()
    {
        string languageSetings = PlayerPrefs.GetString("language");
        string[] language = _russianText;
        Vector2[] pos = _elemetsPosRus;
        if (languageSetings == "Rus")
        {
            language = _russianText;
            pos = _elemetsPosRus;
            _language.value = 0;
            Debug.Log("Load Russian");
        }
        else
        {
            if (languageSetings == "Eng")
            {
                language = _englishText;
                pos = _elemetsPosEng;
                _language.value = 1;
                Debug.Log("Load English");
            }
            else
            {
                PlayerPrefs.SetString("language", "Rus");
                language = _russianText;
                pos = _elemetsPosRus;
                _language.value = 0;
                Debug.Log("Load Russian");
            }
        }

        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].text = language[i];
        }
        Debug.Log("Text " + languageSetings + " load");
        for (int i = 0; i < _elemetsUI.Length; i++)
        {
            Debug.Log("pos UI element " + i + " = " + _elemetsUI[i].transform.position);
            _elemetsUI[i].transform.position = pos[i];
        }
        Debug.Log("Pos load");
        _saingDelay.value = PlayerPrefs.GetFloat("SaingDlay");
        Debug.Log("Saing dlay load");
    }
}
