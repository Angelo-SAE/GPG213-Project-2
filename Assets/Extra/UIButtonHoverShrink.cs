using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHoverShrink : MonoBehaviour
{
    [SerializeField] private RectTransform uiToDetect;
    private bool isHovering;
    private Vector2 mousePosition, bounds;

    private void Start()
    {
      bounds.x = uiToDetect.sizeDelta.x / 2;
      bounds.y = uiToDetect.sizeDelta.y / 2;
    }

    private void Update()
    {
      GetMousePosition();
      if(isHovering)
      {
        CheckForExit();
      } else {
        CheckForHover();
      }

    }

    private void GetMousePosition()
    {
      mousePosition = Input.mousePosition;
    }

    private void CheckForHover()
    {
      if(mousePosition.x > uiToDetect.position.x - bounds.x && mousePosition.x < uiToDetect.position.x + bounds.x && mousePosition.y > uiToDetect.position.y - bounds.y && mousePosition.y < uiToDetect.position.y + bounds.y)
      {
        isHovering = true;
        transform.localScale = new Vector2(0.9f, 0.9f);
      }
    }

    private void CheckForExit()
    {
      if(mousePosition.x < uiToDetect.position.x - bounds.x || mousePosition.x > uiToDetect.position.x + bounds.x || mousePosition.y < uiToDetect.position.y - bounds.y || mousePosition.y > uiToDetect.position.y + bounds.y)
      {
        isHovering = false;
        transform.localScale = new Vector2(1f, 1f);
      }
    }
}
