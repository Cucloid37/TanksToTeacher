using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestCoroutine
{

    // начать день с того, чтобы по данной схеме реализовать
    // ЗАДАЧА:
    // Корутина 1: Пуля вынимается из пула, летит до цели, происходит Дамаж (урон + анимация)
    // Корутина 2: Получает следующий танк из списка и запускает Корутина 1 
    
    
    // нужен Монобех, который запускает корутины
    
    
    public class MovableObjectScript : MonoBehaviour
    {
        public bool IsMoving = false;

        public IEnumerator MoveCoroutine(Vector3 moveTo)
        {
            IsMoving = true;

            // делаем переход от текущей позиции к новой
            var iniPosition = transform.position;
            while (transform.position != moveTo)
            {
                // тут меняем текущую позицию с учетом скорости и прошедшего с последнего фрейма времени
                // и ждем следующего фрейма
                yield return null;
            }

            IsMoving = false;
        }
    }

    public class AnyCoroutines : MonoBehaviour
    {
        private MovableObjectScript[] objectsToMove;
        private Vector3 moveTo;
        
        IEnumerator PerformMovingCoroutine()
        {
            // делаем дела

            foreach(MovableObjectScript s in objectsToMove)
            {
                // определяем позицию
                StartCoroutine(s.MoveCoroutine(moveTo));
            }

            bool isMoving = true;
            while (isMoving) 
            {
                isMoving = false;
                Array.ForEach(objectsToMove, s => { if (s.IsMoving) isMoving = true; });
                if (isMoving) yield return null;
            }

            // делаем еще дела
        }
    }

    public static class CoroutineExtension
    {
        // для отслеживания используем словарь <название группы, количество работающих корутинов>
        static private readonly Dictionary<string, int> Runners = new Dictionary<string, int>();

        // MonoBehaviour нам нужен для запуска корутина в контексте вызывающего класса
        public static void ParallelCoroutinesGroup(this IEnumerator coroutine, MonoBehaviour parent, string groupName)
        {
            if (!Runners.ContainsKey(groupName))
                Runners.Add(groupName, 0);

            Runners[groupName]++;
            parent.StartCoroutine(DoParallel(coroutine, parent, groupName));
        }
	

        static IEnumerator DoParallel(IEnumerator coroutine, MonoBehaviour parent, string groupName)
        {
            yield return parent.StartCoroutine(coroutine);
            Runners[groupName]--;
        }
	
        // эту функцию используем, что бы узнать, есть ли в группе незавершенные корутины
        public static bool GroupProcessing(string groupName)
        {
            return (Runners.ContainsKey(groupName) && Runners[groupName] > 0);
        }
    }

    public class TestStart : MonoBehaviour
    {
        IEnumerator GlobalCoroutine()
        {
            for (int i = 0; i < 5; i++)
                RegularCoroutine(i).ParallelCoroutinesGroup(this, "test");

            while (CoroutineExtension.GroupProcessing("test"))
                yield return null;

            Debug.Log("Group 1 finished");

            for (int i = 10; i < 15; i++)
                RegularCoroutine(i).ParallelCoroutinesGroup(this, "anotherTest");

            while (CoroutineExtension.GroupProcessing("anotherTest"))
                yield return null;

            Debug.Log("Group 2 finished");
        }

        IEnumerator RegularCoroutine(int id)
        {
            int iterationsCount = Random.Range(1, 5);

            for (int i = 1; i <= iterationsCount; i++)
            {
                yield return new WaitForSeconds(1);
            }

            Debug.Log(string.Format("{0}: Coroutine {1} finished", Time.realtimeSinceStartup, id));
        }
    }
}