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

    // 관찰자를 등록
    public void AddObserver(IInvetoryObserver observer)
    {
        _observers.Add(observer);
    }

    // 관찰자를 해제
    public void RemoveObserver(IInvetoryObserver observer)
    {
        _observers.Remove(observer);
    }

    // 관찰자에게 체력을 알림
    private void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.AddItem(_item);
        }
    }

    // 관리할 메서드
    public void ModifyObsever(Item item)
    {
        _item = item;

        NotifyObsever();
    }
}
