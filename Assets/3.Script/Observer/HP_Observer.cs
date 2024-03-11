using System.Collections.Generic;

public interface IHPObserver
{
    void OnHPChanged(float newHealth);
}

public class HP_Observer
{
    private float _hp = 0f;

    private List<IHPObserver> _observers = new List<IHPObserver>();

    // �����ڸ� ���
    public void AddObserver(IHPObserver observer)
    {
        _observers.Add(observer);
    }

    // �����ڸ� ����
    public void RemoveObserver(IHPObserver observer)
    {
        _observers.Remove(observer);
    }

    // �����ڿ��� ü���� �˸�
    public void NotifyObsever()
    {
        foreach (var observer in _observers)
        {
            observer.OnHPChanged(_hp);
        }
    }

    // ������ �޼���
    public void ModifyObsever(float currentHP, float maxHP)
    {
        _hp = currentHP / maxHP;

        NotifyObsever();
    }
}
