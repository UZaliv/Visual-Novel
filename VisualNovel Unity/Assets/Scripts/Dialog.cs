using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] string[] _saingRus;
    [SerializeField] string[] _saingEng;
    [SerializeField] TextMeshProUGUI _dialogWindow;
    [SerializeField] AudioSource _sounds;
    [SerializeField] AudioClip[] _audioDialogRus;
    [SerializeField] AudioClip[] _audioDialogEng;
    bool _isSaing;
    float _saingDelay;

    private void Start()
    {
        _saingDelay = PlayerPrefs.GetFloat("SaingDlay");
        Debug.Log("load Saing dlay");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)&!_isSaing)
        {
            _dialogWindow.text = "";
            _isSaing = true;
            Debug.Log("Saing start");
            StartCoroutine(Saing());
        }
    }
    IEnumerator Saing()
    {
        string saing = _saingRus[0];
        AudioClip audioDialog = _audioDialogRus[0];
        string language = PlayerPrefs.GetString("language");
        if (language == "Rus")
        {
            saing = _saingRus[0];
            audioDialog = _audioDialogRus[0];
            Debug.Log("load Rus");
        }
        else
        {
            if(language == "Eng")
            {
                saing = _saingEng[0];
                audioDialog = _audioDialogEng[0];
                Debug.Log("load Eng");
            }
        }
        _sounds.PlayOneShot(audioDialog);
        for(int i = 0;i<saing.Length; i++)
        {
            _dialogWindow.text += saing[i];
            yield return new WaitForSeconds(_saingDelay);
        }
        _isSaing =false;
        Debug.Log("Saing end");
        yield return null;
    }
}
