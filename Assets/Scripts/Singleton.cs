using UnityEngine;

/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	private static bool _IsApplicationQuitting = false;
	private static object _lock = new object();

	public static T Instance
	{
		get
		{
			if (_IsApplicationQuitting)
			{
				Debug.LogWarning($"[Singleton] Trying to access destroyed Singleton [{typeof(T)}]");
				return null;
			}

			lock (_lock)
			{
				if (_instance != null)
				{
					return _instance;
				}

				_instance = (T) FindObjectOfType(typeof(T));

				if (FindObjectsOfType(typeof(T)).Length > 1)
				{
					Debug.LogError($"[Singleton] More then one Singleton of type [{typeof(T)}]");
					return _instance;
				}

				if (_instance == null)
				{
					var singleton = new GameObject();
					_instance = singleton.AddComponent<T>();
					singleton.name = "(singleton) " + typeof(T);

					Debug.Log("[Singleton] An instance of " + typeof(T) +
					          " is needed in the scene, so '" + singleton +
					          "' was created.");
				}

				return _instance;
			}
		}
	}

	private static bool HasDontDestroyOnLoad()
	{
		if (_instance == null)
		{
			return false;
		}

		// Object exists independent of Scene lifecycle, assume that means it has DontDestroyOnLoad set
		return _instance.gameObject.hideFlags.HasFlag(HideFlags.DontSave);
	}


	/// <summary>
	/// When Unity quits, it destroys objects in a random order.
	/// In principle, a Singleton is only destroyed when application quits.
	/// If any script calls Instance after it have been destroyed, 
	///   it will create a buggy ghost object that will stay on the Editor scene
	///   even after stopping playing the Application. Really bad!
	/// So, this was made to be sure we're not creating that buggy ghost object.
	/// </summary>
	public void OnDestroy()
	{
		if (HasDontDestroyOnLoad())
		{
			_IsApplicationQuitting = true;
		}
	}
}