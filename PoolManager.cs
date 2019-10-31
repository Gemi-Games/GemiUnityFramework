/**
 * 
 *  Copyright (C) 2019 Marios Kalogerou
 * 
 *  This file is part of Gemi Games Unity Framework (GemiFramework).
 * 
 *  GemiFramework is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  GemiFramework is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with GemiFramework. If not, see <http://www.gnu.org/licenses/>.
 * 
 **/

using System.Collections.Generic;
using UnityEngine;

namespace GemiFramework
{

    public struct PoolInfo
    {
        public int PrefabID;

        public int PoolSize;

        public GameObject PoolHolder;
    }

    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<int, Queue<ObjectInstance>> m_Dictionary = new Dictionary<int, Queue<ObjectInstance>>();
        private Dictionary<int, PoolInfo> m_Infos = new Dictionary<int, PoolInfo>();

        private List<int> m_PrefabIDs;

        public void CreatePool(GameObject lPrefab, int lPoolSize)
        {
            CreatePool(lPrefab, lPoolSize, false);
        }

        public void CreatePool(GameObject lPrefab, int lPoolSize, bool lReverseOrder)
        {
            int lKey = lPrefab.gameObject.GetInstanceID();

            if (m_Dictionary.ContainsKey(lKey))
                return;

            if (m_PrefabIDs == null)
                m_PrefabIDs = new List<int>(64);

            m_PrefabIDs.Add(lKey);

            GameObject lPoolHolder = new GameObject(lPrefab.name + " Pool");
            lPoolHolder.transform.parent = transform;
            lPoolHolder.isStatic = true;

            PoolInfo lInfo = new PoolInfo();
            lInfo.PoolHolder = lPoolHolder;
            lInfo.PoolSize = lPoolSize;

            m_Dictionary.Add(lKey, new Queue<ObjectInstance>());
            m_Infos.Add(lKey, lInfo);

            if (lReverseOrder)
            {
                for (int i = lPoolSize - 1; i >= 0; i--)
                {
                    GameObject lObject = Instantiate(lPrefab);
                    lObject.isStatic = true;

                    lObject.transform.parent = lPoolHolder.transform;

                    ObjectInstance lInstance = new ObjectInstance(lObject);

                    m_Dictionary[lKey].Enqueue(lInstance);
                }
            }
            else
            {
                for (int i = 0; i < lPoolSize; i++)
                {
                    GameObject lObject = Instantiate(lPrefab);
                    lObject.isStatic = true;

                    lObject.transform.parent = lPoolHolder.transform;

                    ObjectInstance lInstance = new ObjectInstance(lObject);

                    m_Dictionary[lKey].Enqueue(lInstance);
                }
            }
        }

        public void ReparentAndDisactivateAllPools()
        {
            int lCount = m_PrefabIDs.Count;

            for (int i = 0; i < lCount; i++)
                ReparentAndDisactivatePool(m_PrefabIDs[i]);
        }

        public void ReparentAndDisactivatePool(GameObject lPrefab)
        {
            ReparentAndDisactivatePool(lPrefab.gameObject.GetInstanceID());
        }

        private void ReparentAndDisactivatePool(int lPrefabID)
        {
            int lKey = lPrefabID;

            if (m_Dictionary.ContainsKey(lKey))
            {
                Queue<ObjectInstance> lQueue = m_Dictionary[lKey];
                PoolInfo lInfo = m_Infos[lKey];

                for (int i = 0; i < lQueue.Count; i++)
                {
                    ObjectInstance lObjectInstance = lQueue.Dequeue();

                    lObjectInstance.Object.transform.parent = lInfo.PoolHolder.transform;
                    lObjectInstance.Object.SetActive(false);

                    lQueue.Enqueue(lObjectInstance);
                }
            }
        }

        public GameObject ReuseObject(GameObject lPrefab)
        {
            return ReuseObject(lPrefab, Vector3.zero, Quaternion.identity);
        }

        public GameObject ReuseObject(GameObject lPrefab, Vector3 lPosition)
        {
            return ReuseObject(lPrefab, lPosition, Quaternion.identity);
        }

        public GameObject ReuseObject(GameObject lPrefab, Vector3 lPosition, Quaternion lRotation, bool lCreatePool = false)
        {
            int lKey = lPrefab.gameObject.GetInstanceID();

            if (m_Dictionary.ContainsKey(lKey))
            {
                ObjectInstance lInstance = m_Dictionary[lKey].Dequeue();

                m_Dictionary[lKey].Enqueue(lInstance);
                lInstance.Reuse(lPosition, lRotation);

                return lInstance.Object;
            }
            else if (lCreatePool)
            {
                CreatePool(lPrefab, 128);

                return ReuseObject(lPrefab, lPosition, lRotation);
            }

            return null;
        }

        public class ObjectInstance
        {
            public GameObject Object;

            Transform m_Transform;

            bool m_HasScript;
            PoolObject m_PoolObjectScript;

            public ObjectInstance(GameObject lObjectInstance)
            {
                Object = lObjectInstance;
                m_Transform = Object.transform;

                m_PoolObjectScript = Object.GetComponent<PoolObject>();

                if (m_PoolObjectScript != null)
                    m_HasScript = true;
                else
                    m_HasScript = false;

                Object.SetActive(false);
            }

            public void Reuse(Vector3 lPosition, Quaternion lRotation)
            {
                if (m_HasScript)
                    m_PoolObjectScript.OnSpawn();

                Object.SetActive(true);
                m_Transform.position = lPosition;
                m_Transform.rotation = lRotation;
            }
        }
    }
}