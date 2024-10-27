using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    // ������ �� ������, �� �������� ����� ����������� �������
    public T prefab { get; }

    // ���������� ��� �������������� ����
    public bool autoExpand { get; set; }

    // ��������� ���� ��������, ������� ����� ������������ � ���������
    public Transform container { get; }

    // ��� ����� ��������� ��� ��������� �������
    private List<T> pool;

   /// <summary>
   /// ��� 1, � ������� �� �������� ������ � ������� ����� ����
   /// </summary>
   /// <param name="prefab"></param>
   /// <param name="count"></param>
    public PoolMono(T prefab, int count)
    {
        this.prefab = prefab;        
        this.container = null;

        this.CreatePool(count);
    }
    /// <summary>
    /// ��� 2, � ������� �� �������� ������, ������� � ������ �� ���������
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="count"></param>
    /// <param name="container"></param>
    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        this.CreatePool(count);
    }

    /// <summary>
    /// ����� �������� ����
    /// </summary>
    /// <param name="count"></param>
    private void CreatePool(int count)
    {
        // ���������� ���������� ����
        this.pool = new List<T>();

        // ������� �������
        for (int i = 0; i < count; i++)
        {
            this.CreatObject();
        }
    }

    /// <summary>
    /// ����� ��� �������� �������� (��� ��������� ������� ����� ���������)
    /// </summary>
    /// <param name="isActiveByDefault"></param>
    /// <returns></returns>
    private T CreatObject(bool isActiveByDefault = false)
    {
        // ������� ������
        var createdObject = Object.Instantiate(this.prefab, this.container);

        // ��������� ������
        createdObject.gameObject.SetActive(isActiveByDefault);

        // �������� ������ � ���
        this.pool.Add(createdObject);

        // ���������� ���
        return createdObject;
    }

    /// <summary>
    /// ����� ���������� ���� �� ��������� ������, ������������� ����� ����� �������� �������, ���� �� ����
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool HasFreeElement(out T element)
    {
        // �������� �� ���� �������� ����
        foreach (var mono in pool)
        {
            // ���� ������ ��������, �� ����������
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;

                mono.gameObject.SetActive(true);

                return true;
            }
        }

        element = null;

        return false;
    }

    /// <summary>
    /// ����� ��������� �������
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception"></exception>
    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
            return this.CreatObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }
}
