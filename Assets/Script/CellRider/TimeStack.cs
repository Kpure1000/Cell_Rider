using System;
/// <summary>
/// 时间回溯容器(支持出栈的循环队列)
/// </summary>
/// <typeparam name="T"></typeparam>
public class TimeStack<T>
{
    private T[] _array;

    private int _front;

    private int _rear;

    public int MaxSize;

    public TimeStack(int maxSize)
    {
        _array = new T[maxSize];
        MaxSize = maxSize;

        _front = _rear = 0;
    }
    /// <summary>
    /// 压栈，覆盖
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        //Debug.Log(string.Format("Fonrt: {0}, Rear: {1}", _front, _rear));

        _front = (_front + 1) % MaxSize;

        //首尾相接
        if (_front == _rear)
        {
            _rear = (_front + 1) % MaxSize;
        }

        _array[_front] = value;
    }
    /// <summary>
    /// 安全的出栈方法
    /// </summary>
    public void Pop()
    {
        if (isEmpty()) 
            return;

        _front = (_front + MaxSize - 1) % MaxSize;

    }
    /// <summary>
    /// 不安全的栈顶，最好先判断isEmpty
    /// </summary>
    /// <returns></returns>
    public T Top()
    {
        if (isEmpty() == false)
        {
            return _array[_front];
        }
        return default;
    }
    public bool isFull()
    {
        return (_front + 1) % MaxSize == _rear;
    }
    /// <summary>
    /// 是否为空
    /// </summary>
    /// <returns></returns>
    public bool isEmpty()
    {
        return _front == _rear;
    }
}
