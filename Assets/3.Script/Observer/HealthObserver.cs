using System.Collections.Generic;
using System.Net.NetworkInformation;

public interface IHealthObserver
{
    void OnHealthChanged(float newHealth);
}

public class HealthObserver
{
    private float _hp = 0f;

    private List<IHealthObserver> _observers = new List<IHealthObserver>();

    // 관찰자를 등록
    public void AddObserver(IHealthObserver observer)
    {
        _observers.Add(observer);
    }

    // 관찰자를 해제
    public void RemoveObserver(IHealthObserver observer)
    {
        _observers.Remove(observer);
    }

    // 관찰자에게 체력을 알림
    private void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.OnHealthChanged(_hp);
        }
    }

    // 관리할 메서드
    public void ModifyObsever(float currentHP, float maxHP)
    {
        _hp = currentHP / maxHP;

        NotifyObsever();
    }
}
