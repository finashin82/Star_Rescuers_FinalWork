using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    // Ссылка на префаб, из которого будут создаваться объекты
    public T prefab { get; }

    // Переменная для авторасширения пула
    public bool autoExpand { get; set; }

    // Трансформ всех объектов, которые будут скрадываться в контейнер
    public Transform container { get; }

    // Где будут храниться все созданные объекты
    private List<T> pool;

   /// <summary>
   /// Пул 1, в который мы передаем префаб и емкость этого пула
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
    /// Пул 2, в который мы передаем префаб, емкость и ссылку на контейнер
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
    /// Метод создания пула
    /// </summary>
    /// <param name="count"></param>
    private void CreatePool(int count)
    {
        // Определяем переменную пула
        this.pool = new List<T>();

        // Создаем объекты
        for (int i = 0; i < count; i++)
        {
            this.CreatObject();
        }
    }

    /// <summary>
    /// Метод для создания объектов (все созданные объекты будут отключены)
    /// </summary>
    /// <param name="isActiveByDefault"></param>
    /// <returns></returns>
    private T CreatObject(bool isActiveByDefault = false)
    {
        // Создаем объект
        var createdObject = Object.Instantiate(this.prefab, this.container);

        // Выключаем объект
        createdObject.gameObject.SetActive(isActiveByDefault);

        // Помещаем объект в пул
        this.pool.Add(createdObject);

        // Возвращаем его
        return createdObject;
    }

    /// <summary>
    /// Метод показывает есть ли свободный объект, дополнительно можем сразу вытащить элемент, если он есть
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool HasFreeElement(out T element)
    {
        // Проходим по всем объектам пула
        foreach (var mono in pool)
        {
            // Если объект свободен, но возвращаем
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
    /// Берем свободный элемент
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
