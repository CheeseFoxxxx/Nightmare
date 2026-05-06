using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int possibleItemDrop;
    [SerializeField] private ItemData[] possibleDrop;
    private List<ItemData> dropList = new List<ItemData>();

    [SerializeField] private GameObject dropPrefab;
    public virtual void GenerateDrop()
    {

        dropList.Clear();

        // 第一阶段：严格按概率筛选
        foreach (var item in possibleDrop)
        {
            if (Random.Range(0, 100) < item.dropChance)
            {
                dropList.Add(item);
            }
        }

        // 如果无物品通过概率检查，保底掉落1个随机物品
        if (dropList.Count == 0)
        {
            ItemData fallbackItem = possibleDrop[Random.Range(0, possibleDrop.Length)];
            DropItem(fallbackItem);
            return;
        }

        // 第二阶段：随机抽取，不超过possibleItemDrop
        int dropsToGenerate = Mathf.Min(possibleItemDrop, dropList.Count);
        for (int i = 0; i < dropsToGenerate; i++)
        {
            int randomIndex = Random.Range(0, dropList.Count);
            DropItem(dropList[randomIndex]);
            dropList.RemoveAt(randomIndex);
        }
    }
    protected void DropItem(ItemData _itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab,transform.position,Quaternion.identity);

        Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(15,20));
        newDrop.GetComponent<ItemObject>().SetupItem(_itemData,randomVelocity);
    }
}
