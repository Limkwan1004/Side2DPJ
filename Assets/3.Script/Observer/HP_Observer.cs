using System.Collections.Generic;

public interface IHPObserver
{
    void OnHPChanged(float newHealth);
}

public class HP_Observer
{
    private float _hp = 0f;

    private List<IHPObserver> _observers = new List<IHPObserver>();

    // 관찰자를 등록
    public void AddObserver(IHPObserver observer)
    {
        _observers.Add(observer);
    }

    // 관찰자를 해제
    public void RemoveObserver(IHPObserver observer)
    {
        _observers.Remove(observer);
    }

    // 관찰자에게 체력을 알림
    public void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.OnHPChanged(_hp);
        }
    }

    // 관리할 메서드
    public void ModifyObsever(float currentHP, float maxHP)
    {
        _hp = currentHP / maxHP;

        NotifyObsever();
    }
}
