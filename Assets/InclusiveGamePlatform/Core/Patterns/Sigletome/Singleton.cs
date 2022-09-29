namespace InclusiveGamePlatform.Core.Patterns.Singleton
{
    using UnityEngine;
    /// <summary>
    /// Паттерн одиночки, создающий игровой объект на сцене и вешающий на него компонет указаного типа
    /// </summary>
    /// <typeparam name="T">Добавляемый компонент</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance = null;

        /// <summary>
        /// Получение экземпляра объекта
        /// </summary>
        public static T Instance { 
            get {
                if (instance == null)
                {
                    GameObject obj = new GameObject("[" + typeof(T) +"]");
                    instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }

                return instance;
            } 
        }
    }

}
 