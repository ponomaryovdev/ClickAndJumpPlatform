namespace InclusiveGamePlatform.Core.Patterns.Singleton
{
    using UnityEngine;
    /// <summary>
    /// ������� ��������, ��������� ������� ������ �� ����� � �������� �� ���� �������� ��������� ����
    /// </summary>
    /// <typeparam name="T">����������� ���������</typeparam>
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance = null;

        /// <summary>
        /// ��������� ���������� �������
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
 