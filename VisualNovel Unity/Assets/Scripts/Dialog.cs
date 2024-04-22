using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] string _saing;
    [SerializeField] TextMeshProUGUI _dialogWindow;
    [SerializeField] Slider _saingDelay;
    [SerializeField] AudioSource _sounds;
    [SerializeField] AudioClip[] _audioDialog;
    bool _isSaing;

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
        _sounds.PlayOneShot(_audioDialog[0]);
        for(int i = 0;i<_saing.Length; i++)
        {
            _dialogWindow.text += _saing[i];
            yield return new WaitForSeconds(_saingDelay.value);
        }
        _isSaing =false;
        Debug.Log("Saing end");
        yield return null;
    }
}
