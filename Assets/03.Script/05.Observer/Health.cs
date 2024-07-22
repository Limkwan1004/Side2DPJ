using System.Collections.Generic;
using System.Net.NetworkInformation;

public interface IHealthObserver
{
    void OnHealthChanged(float newHealth);
}

public class Health
{
    private float _health;

    private List<IHealthObserver> _observers = new List<IHealthObserver>();

    public void AddObserver(IHealthObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IHealthObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.OnHealthChanged(_health);
        }
    }

    public void ModifyObsever(float currentHP, float maxHP)
    {
        _health = currentHP / maxHP;

        NotifyObsever();
    }
}
