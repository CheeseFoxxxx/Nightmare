using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ToolTip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void AdjustPosition()
    {
        Vector2 mousePosition = Input.mousePosition;

        float xOffset = 0;
        float yOffset = 0;
        // 获取屏幕宽度和高度
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 使用屏幕宽度和高度的百分比来计算偏移量
        if (mousePosition.x > screenWidth * 0.5f) // 屏幕宽度的一半
        {
            xOffset = -screenWidth * 0.1f; // 屏幕宽度的10%
        }
        else
        {
            xOffset = screenWidth * 0.1f; // 屏幕宽度的10%
        }

        if (mousePosition.y > screenHeight * 0.5f) // 屏幕高度的一半
        {
            yOffset = -screenHeight * 0.1f; // 屏幕高度的10%
        }
        else
        {
            yOffset = screenHeight * 0.1f; // 屏幕高度的10%
        }

        transform.position = new Vector2(mousePosition.x + xOffset, mousePosition.y + yOffset);
    }

    
}
