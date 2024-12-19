using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnConstruction : MonoBehaviour
{

    private Construction _currentSelectedBuilding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.gameObject.TryGetComponent<Construction>(out Construction obj))
            {
                obj.OnHighlight();

                if (Input.GetMouseButtonDown(0)) { 
                
                    ChangeConstruction(obj);

                }
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
