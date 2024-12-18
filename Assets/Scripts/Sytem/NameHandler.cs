using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameHandler : MonoBehaviour
{

    private string _name;
    [SerializeField] private TextMeshProUGUI _tmp;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += TransmitTextToGameManager;
    }

    public void TransmitTextToGameManager(Scene arg0, Scene arg1)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance._name = _name;
        }
        else
        {
            throw new System.Exception("GameManager n'est pas la");
        }
        Destroy(gameObject);
    }

    public void ChangeScene()
    {
        _name = _tmp.text;
        SceneManager.LoadScene("Map");
    }

}
