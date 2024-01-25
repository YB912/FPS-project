
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Private Fields
    protected static T _instance;

    // Making the class thread-safe, eliminating the creation chance of multiple instances by multiple threads
    private static readonly object _synchronizationObject = new object();
    #endregion

    public static T instance
    {
        get
        {
            lock (_synchronizationObject)
            {
                if (_instance == null) // If the instance is somehow set to null after being created in Awake
                {
                    _instance = FindObjectOfType<T>(); // Only accepts Ts that also inherit MonoBehaviour

                    if (_instance == null) // If the instance is somehow destroyed after being created in Awake
                    {
                        GameObject gameObject = new GameObject(typeof(T).ToString());
                        _instance = gameObject.AddComponent<T>();
                        DontDestroyOnLoad(gameObject);
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (instance == null) 
        { 
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
