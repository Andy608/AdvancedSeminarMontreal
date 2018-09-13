using UnityEngine;

namespace Managers
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        //The singleton will create a single (and only one) static instance of a class that inherits from it, making it accessible to all other classes. 
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                }
                else if (instance != FindObjectOfType<T>())
                {
                    Destroy(FindObjectOfType<T>());
                }

                return instance;
            }
        }
    }
}