using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Miscellaneous
{
    /// <summary>
    /// Object pool pattern implementation.
    /// </summary>
    /// <remarks>
    /// This pattern caches some amount of frequently used prefabs, and caches some of their instances
    /// to avoid unnecessary instantiating\destroying to avoid some GC spikes 
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Prefab, which instances will be cached
        /// </summary>
        private readonly T _prefab;

        private readonly List<T> _pool = new List<T>();

        /// <summary>
        /// </summary>
        /// <param name="prefab">Prefab, which instances you will get from this pool</param>
        /// <param name="poolSize">Precreated instances count</param>
        public ObjectPool(T prefab, int poolSize = 1)
        {
            _prefab = prefab;
            for (int i = 0; i < poolSize; i++)
            {
                var newObject = GameObject.Instantiate(_prefab);
                newObject.gameObject.SetActive(false);
                _pool.Add(newObject);
            }
        }

        /// <summary>
        /// Get object from pool. Instantiates new object if there is no already free instances
        /// </summary>
        /// <returns></returns>
        public T GetObject()
        {
            var obj = _pool.FirstOrDefault(x => !x.gameObject.activeInHierarchy);
            if (obj != default)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }

            var newObj = GameObject.Instantiate(_prefab);
            _pool.Add(newObj);
            return newObj;
        }

        /// <summary>
        /// Return object to pool
        /// </summary>
        /// <param name="obj"></param>
        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}