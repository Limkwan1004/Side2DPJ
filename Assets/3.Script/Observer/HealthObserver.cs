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

    // �����ڸ� ���
    public void AddObserver(IHealthObserver observer)
    {
        _observers.Add(observer);
    }

    // �����ڸ� ����
    public void RemoveObserver(IHealthObserver observer)
    {
        _observers.Remove(observer);
    }

    // �����ڿ��� ü���� �˸�
    private void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.OnHealthChanged(_hp);
        }
    }

    // ������ �޼���
    public void ModifyObsever(float currentHP, float maxHP)
    {
        _hp = currentHP / maxHP;

        NotifyObsever();
    }
}
