using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnConstruction : Singleton<ClickOnConstruction>
{

    private Construction _currentSelectedBuilding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.CurrentWindow == null)
        {
            //if (GameManager.Instance._currentStep > 1)
            //{
            //    CheckIfClickedOutsideWindow();
            //}
            CheckIfBuildingClicked();
        }
    }

    public void CheckIfClickedOutsideWindow()
    { 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (GameManager.Instance.CurrentWindow.TryGetComponent<RectTransform>(out RectTransform trans)) {
                if (!IsPointerInsideUI(trans))
                {
                    GameManager.Instance.ChangeWindow(null);
                }
            }
        }
    }

    private bool IsPointerInsideUI(RectTransform rectTransform)
    {
        Vector2 mousePosition = Input.mousePosition;

        // Convertir la position de la souris en coordonnées locales par rapport au RectTransform
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform,
            mousePosition,
            Camera.main, // Utilisez la caméra du Canvas, si ce n'est pas la caméra principale
            out Vector2 localPoint
        );

        // Vérifier si le point local est dans les limites du RectTransform
        return rectTransform.rect.Contains(localPoint);
    }

    public void CheckIfBuildingClicked()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.TryGetComponent<Construction>(out Construction obj))
            {
                ChangeConstruction(obj);
            }
        }
        else
        {
            return;
        }
    }

    public void ChangeConstruction(Construction construction) 
    {
        if (_currentSelectedBuilding != null)
        {
            _currentSelectedBuilding.OnUnselected();
        }

        _currentSelectedBuilding = construction;

        if (_currentSelectedBuilding != null)
        {
            _currentSelectedBuilding.OnSelected();
        }
    }

    public void ResetConstrcution()
    {
        ChangeConstruction(null);
    }

}
