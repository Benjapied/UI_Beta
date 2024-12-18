using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ElementUpgrade : MonoBehaviour
{

    public event GameManager.UpdateText OnChangeDescription;
    public event GameManager.UpdateNumber OnChangePrice;
    public event GameManager.UpdateText OnChangeName;

    Upgrade _upgrade;
    [SerializeField] Button _button;

    public Upgrade Upgrade { set => _upgrade = value; }
    void Start()
    {
        _button.interactable = false;
        Init();
    }

    void Init()
    {
        OnChangePrice?.Invoke(_upgrade.Price);
        OnChangeDescription?.Invoke(_upgrade.Description);
        OnChangeName?.Invoke(_upgrade.Title);
        GameManager.Instance.Business.OnChangeMoney += EnableButton;
    }

    public void BuyUpgrade()
    {
        GameManager.Instance.Business.RemoveMoney(_upgrade.Price);
        _upgrade.Do();
    }


    private void EnableButton(float money)
    {
        if (money >= _upgrade.Price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
}
