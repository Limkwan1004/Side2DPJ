using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvetoryObserver
{
    void AddItem(Item item);
}

public class InventoryObserver : MonoBehaviour
{
    private Item _item;

    private List<IInvetoryObserver> _observers = new List<IInvetoryObserver>();

    // �����ڸ� ���
    public void AddObserver(IInvetoryObserver observer)
    {
        _observers.Add(observer);
    }

    // �����ڸ� ����
    public void RemoveObserver(IInvetoryObserver observer)
    {
        _observers.Remove(observer);
    }

    // �����ڿ��� ü���� �˸�
    private void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.AddItem(_item);
        }
    }

    // ������ �޼���
    public void ModifyObsever(Item item)
    {
        _item = item;

        NotifyObsever();
    }
}
