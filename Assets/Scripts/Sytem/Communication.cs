using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour
{

    [SerializeField] private float timer = 60f;

    private int[] _coeffTab = { 150, 150, 150, 150 };

    [SerializeField] GameObject[] _coeffs;

    public GameManager.UpdateNumber[] OnChangeCoeff = new GameManager.UpdateNumber[4];


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAll()
    {
        for (int i = 0; i < _coeffTab.Length; i++)
        {
            OnChangeCoeff[i]?.Invoke(_coeffTab[i]);
        }
    }

    public void Invest(int index)
    {
        GameManager.Instance.Business.UpdateVisibility(_coeffTab[index] * 0.01f);
        for(int i = 0; i < _coeffTab.Length; i++)
        {
            if(i == index)
            {
                _coeffTab[i] -= 30;
            }
            else
            {
                _coeffTab[i] += 10;
            }
        }
        UpdateAll();

        StartCoroutine(BalanceCoeff());

    }

    public IEnumerator BalanceCoeff()
    {
        if(GameManager.Instance.Business.Visibility == 1)
        {
            yield return null;
        }

        yield return new WaitForSeconds(timer);

        if (GameManager.Instance.Business.Visibility >= 1) {

            GameManager.Instance.Business.UpdateVisibility(GameManager.Instance.Business.Visibility - 0.1f);
        }
        else
        {
            GameManager.Instance.Business.UpdateVisibility(GameManager.Instance.Business.Visibility + 0.1f);
        }
        StartCoroutine(BalanceCoeff());
    }

    public void UpgradeCom()
    {
        foreach(GameObject coef in _coeffs)
        {
            coef.SetActive(true);
        }
    }

}


