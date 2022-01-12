using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }   //свойство читается откуда угодно, но задается только в этом сценарии
    private Dictionary<string, int> _items;   
    public string equippedItem { get; private set; }
    public void Startup()
    {
        Debug.Log("Inventory manager starting..."); //сюда идут все задачи запуска с долгим временем выполнения
        _items = new Dictionary<string, int>();  //инициализируем пустой список
        status = ManagerStatus.Started;    //для задач с долгим временем выполнения используем состояния "Initializing"
    }
    private void DisplayItems()    //выводим на консоль сообщения о текущем инвентаре
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item + " ";
        }
        Debug.Log(itemDisplay);
    }
    public void AddItem(string name)    //другие сценарии не могут напрямую управлять списком элементов, но могут вызывать ээтот метод
    {
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }
        DisplayItems(); 
    }
    public List<string> GetItemList()  //возвращаем список всех клчей словаря
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }
    public int GetItemCount(string name)        //возвращаем количество указанных элементов в инвентаре
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }
    public bool EquipItem(string name)
    {
        if(_items.ContainsKey(name) && equippedItem != name)   //проверяем что в инвентаре есть указанный элемент, но он еще не подготовлен
        {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }
        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }
    public bool ConsumeItem(string name)
    {
        if (_items.ContainsKey(name))   //проверяем есть ли в инвентаре нужный элемент
        {
            _items[name]--;
            if (_items[name] == 0)    //удаляем запись если количесто становится равным 0
            {
                _items.Remove(name);
            }
        }
        else    //отвечаем что в инвентаре нет нужного элемента
        {
            Debug.Log("cannot consume " + name);
            return false;
        }
        DisplayItems();
        return true;
    }
}
