using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemScriptObject : ScriptableObject
{
    public int id; // 物品ID
    public string itemName;
    public ItemType itemType;
    public string description;
    public List<ItemProperty> properties; // 物品属性列表
    public Sprite icon; // 物品图标
    public GameObject prefab; // 物品预制体
}

public enum ItemType
{
    Weapon, // 武器
    Consumable, // 消耗品
}

// 物品属性类，可以根据需要添加更多属性
[Serializable] // 可序列化，使其在Unity Inspector中可编辑
public class ItemProperty
{
    public ItemPropertyType propertyType;
    public int value;
}
public enum ItemPropertyType
{
    Hp, // 生命值
    Energy, // 能量
    MentalValue, // 精神值
    Speed, // 速度
    Attack, // 攻击力
}