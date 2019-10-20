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

using System;
using UnityEngine;

namespace GemiFramework
{
    [Serializable]
    public struct CapsuleCollider2DInfo
    {
        public Vector2 center;
        public Vector2 point1;
        public Vector2 point2;
        public float radius;
    }

    [Serializable]
    public struct CapsuleColliderInfo
    {
        public Vector3 center;
        public Vector3 point1;
        public Vector3 point2;
        public float radius;
    }

    [Serializable]
    public struct BoxColliderInfo
    {
        public Vector3 center;
        public Vector3 halfExtents;
        public Vector3 halfExtentsRotated;
    }

    [Serializable]
    public struct BoxCollider2DInfo
    {
        public Vector2 center;
        public Vector2 halfExtents;
    }

    public enum CapsuleColliderDirection
    {
        Right,
        Up,
        Forward,
    }

    public static class Extensions
    {
        public static Vector3 AddVector2(this Vector3 lV3, Vector2 lV2)
        {
            lV3.x += lV2.x;
            lV3.y += lV2.y;

            return lV3;
        }

        public static Vector2 ToVector2(this Vector3 lV3)
        {
            return new Vector2(lV3.x, lV3.y);
        }

        public static Vector3 ToVector3(this Vector2 lV2)
        {
            return new Vector3(lV2.x, lV2.y, 0f);
        }

        public static Vector2 Rotate(this Vector2 lV2, float lAngle)
        {
            return Quaternion.Euler(0f, 0f, lAngle) * lV2;
        }

        public static Vector2Int ToVector2Int(this Vector3 lV3)
        {
            return new Vector2Int((int)(lV3.x + 0.5f), (int)(lV3.y + 0.5f));
        }

        public static Vector2 ToVector2(this Vector4 lV4)
        {
            return new Vector2(lV4.x, lV4.y);
        }

        public static CapsuleCollider2DInfo GetInfo(this CapsuleCollider2D lCapColl)
        {
            CapsuleCollider2DInfo info = new CapsuleCollider2DInfo();

            bool vertical = lCapColl.direction == CapsuleDirection2D.Vertical;

            Vector2 lDirection = Vector2.right;

            if (vertical)
                lDirection = Vector2.up;

            lDirection = lCapColl.transform.rotation * lDirection;

            Vector2 lNewOffset = lCapColl.transform.rotation * lCapColl.offset;

            float lRadius = vertical ? lCapColl.size.x : lCapColl.size.y;
            float lHalfHeight = vertical ? lCapColl.size.y : lCapColl.size.x;
            lHalfHeight = lHalfHeight * 0.5f - lRadius;


            info.point1 = (Vector2)lCapColl.transform.position + lNewOffset - lDirection * lHalfHeight;
            info.point2 = (Vector2)lCapColl.transform.position + lNewOffset + lDirection * lHalfHeight;
            info.center = (info.point1 + info.point2) * 0.5f;
            info.radius = lRadius;

            return info;
        }

        public static CapsuleColliderInfo GetCapsuleColliderInfo(this CapsuleCollider lCapColl)
        {
            CapsuleColliderInfo info = new CapsuleColliderInfo();

            Vector3 lDirection = Vector3.right;

            if (lCapColl.direction == (int)CapsuleColliderDirection.Up)
                lDirection = Vector3.up;
            else if (lCapColl.direction == (int)CapsuleColliderDirection.Forward)
                lDirection = Vector3.forward;

            lDirection = lCapColl.transform.rotation * lDirection;

            Vector3 lNewCenter = lCapColl.transform.rotation * lCapColl.center;

            float lRadius = lCapColl.radius;
            float lHalfHeight = lCapColl.height * 0.5f - lRadius;

            info.point1 = lCapColl.transform.position + lNewCenter - lDirection * lHalfHeight;
            info.point2 = lCapColl.transform.position + lNewCenter + lDirection * lHalfHeight;
            info.center = (info.point1 + info.point2) * 0.5f;
            info.radius = lRadius;

            return info;
        }

        public static BoxCollider2DInfo GetBoxColliderInfo(this BoxCollider2D lBoxColl)
        {
            BoxCollider2DInfo info = new BoxCollider2DInfo();

            Vector3 lNewCenter = lBoxColl.transform.position + lBoxColl.transform.rotation * lBoxColl.offset;
            Vector3 lNewHalfExtents = lBoxColl.size * 0.5f;

            info.center = lNewCenter;
            info.halfExtents = lNewHalfExtents;

            return info;
        }

        public static BoxColliderInfo GetBoxColliderInfo(this BoxCollider lBoxColl)
        {
            BoxColliderInfo info = new BoxColliderInfo();

            Vector3 lNewCenter = lBoxColl.transform.position + lBoxColl.transform.rotation * lBoxColl.center;
            Vector3 lNewHalfExtents = lBoxColl.size * 0.5f;
            Vector3 lNewHalfExtentsRotated = lBoxColl.transform.rotation * lNewHalfExtents;

            info.center = lNewCenter;
            info.halfExtents = lNewHalfExtents;
            info.halfExtentsRotated = lNewHalfExtentsRotated;

            return info;
        }

        public static bool PointInsideBox(this BoxCollider lBoxCollider, Vector3 lPoint)
        {
            Vector3 lBoxCenter = lBoxCollider.transform.position + lBoxCollider.center;
            Vector3 lDeltaPoint = lPoint - lBoxCenter;

            lDeltaPoint = Quaternion.Inverse(lBoxCollider.transform.rotation) * lDeltaPoint;

            Vector3 lHalfSize = lBoxCollider.size / 2f;

            if (lDeltaPoint.x > lBoxCenter.x - lHalfSize.x && lDeltaPoint.x < lBoxCenter.x + lHalfSize.x &&
                lDeltaPoint.y > lBoxCenter.y - lHalfSize.y && lDeltaPoint.y < lBoxCenter.y + lHalfSize.y &&
                lDeltaPoint.z > lBoxCenter.z - lHalfSize.z && lDeltaPoint.z < lBoxCenter.z + lHalfSize.z)
            {
                return true;
            }

            return false;
        }

        public static int FindFirstLayerIndex(this LayerMask lLayer)
        {
            int lDecimal = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((lDecimal & lLayer) == lDecimal)
                    return i;

                lDecimal *= 2;
            }

            return -1;
        }
    }
}