using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    [System.Serializable]
    public class Tab
    {
        public GameObject panel;
        public Button button;
        public TMP_Text buttonText;
    }

    [SerializeField] Tab[] tabs;
    [SerializeField] Color selectedButtonColor = new Color(217, 217, 217);
    [SerializeField] Color unselectedButtonColor = new Color(55, 55, 55);
    [SerializeField] Color selectedTextColor = Color.black;
    [SerializeField] Color unselectedTextColor = Color.white;

    private int currentTabIndex = 0;

    void Start()
    {
        UpdateTabs();
    }

    public void SwitchTab(int index)
    {
        if (index < 0 || index >= tabs.Length) return;
        currentTabIndex = index;
        UpdateTabs();
    }

    private void UpdateTabs()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            bool isActive = (i == currentTabIndex);
            tabs[i].panel.SetActive(isActive);

            tabs[i].button.image.color = isActive ? selectedButtonColor : unselectedButtonColor;
            tabs[i].buttonText.color = isActive ? selectedTextColor : unselectedTextColor;
        }
    }
}
