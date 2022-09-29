// /*-----------------------------------------
// -------------------------------------------
// Creation Date: #CREATIONDATE#
// Author: #DEVELOPER#
// Description #PROJECTNAME#
// -------------------------------------------
// -----------------------------------------*/

using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Replace with comments...
/// </summary>


namespace InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono
{
    public class Singleton<T> : MonoBehaviour
        where T : Component
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var objs = FindObjectsOfType(typeof(T)) as T[];
                    if (objs.Length > 0)
                        _instance = objs[0];
                    if (objs.Length > 1)
                    {
                        Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                    }
                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = string.Format("_{0}", typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }
}