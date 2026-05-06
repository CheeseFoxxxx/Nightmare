using UnityEngine;

public class UI_ToolTip : MonoBehaviour
{
    [Header("Tooltip Settings")]
    [SerializeField] private float offsetRatio = 0.15f; 
    [SerializeField] private Vector2 customOffset = Vector2.zero; // 自定义额外偏移

    public virtual void AdjustPosition()
    {
        Vector2 mousePosition = Input.mousePosition;

        // 获取屏幕尺寸
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 计算动态偏移量（基于屏幕比例）
        float xOffset = screenWidth * offsetRatio;
        float yOffset = screenHeight * offsetRatio;

        // 根据鼠标位置决定偏移方向
        Vector2 finalOffset = Vector2.zero;

        // X轴方向
        if (mousePosition.x > screenWidth / 2)
        {
            finalOffset.x = -xOffset; // 鼠标在右侧，向左偏移
        }
        else
        {
            finalOffset.x = xOffset;  // 鼠标在左侧，向右偏移
        }

        // Y轴方向
        if (mousePosition.y > screenHeight / 2)
        {
            finalOffset.y = -yOffset; // 鼠标在上方，向下偏移
        }
        else
        {
            finalOffset.y = yOffset;  // 鼠标在下方，向上偏移
        }

        // 应用自定义偏移
        finalOffset += customOffset;

        // 设置位置
        Vector2 targetPosition = mousePosition + finalOffset;

        // 确保Tooltip不超出屏幕边界
        targetPosition = ClampToScreenBounds(targetPosition, screenWidth, screenHeight);

        transform.position = targetPosition;
    }

    // 限制Tooltip在屏幕内
    private Vector2 ClampToScreenBounds(Vector2 position, float screenWidth, float screenHeight)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // 获取Tooltip的尺寸
            Vector2 tooltipSize = rectTransform.sizeDelta;

            // 限制X轴
            position.x = Mathf.Clamp(position.x, tooltipSize.x / 2, screenWidth - tooltipSize.x / 2);

            // 限制Y轴
            position.y = Mathf.Clamp(position.y, tooltipSize.y / 2, screenHeight - tooltipSize.y / 2);
        }
        else
        {
            // 如果没有RectTransform，简单限制在边缘内
            position.x = Mathf.Clamp(position.x, 10, screenWidth - 10);
            position.y = Mathf.Clamp(position.y, 10, screenHeight - 10);
        }

        return position;
    }
}