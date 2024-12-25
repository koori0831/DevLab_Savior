using UnityEngine;

public interface IInitailizeable
{
    public void Initialize();
}
public interface IInitailizeable<T>
{
    public void Initailize(T data);
}
