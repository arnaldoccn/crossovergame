using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrossoverGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ConstantsScriptableObject", menuName = "ScriptableObjects/ConstantsScriptableObject", order = 1)]
    public class ConstantsScriptableObject : ScriptableObject
    {
        public string apiURI;
        public float mouseSensitivity = 3.0f;
        public float distanceFromTarget = 3.0f;
        public float smoothTime = 0.2f;
        public Vector2 rotationXMinMax = new Vector2(-40, 40);
        public string gradeToRemove = "Algebra I";
        public string mastery0 = "NOT LEARNED";
        public string mastery1 = "LEARNED";
        public string mastery2 = "MASTERED";
        public int glassMass = 1;
        public int woodMass = 3;
        public int stoneMass = 8;
        public Vector3 stackAPosition = new Vector3(-10, 0);
        public Vector3 stackBPosition = new Vector3(0, 0);
        public Vector3 stackCPosition = new Vector3(10, 0);
    }
}
