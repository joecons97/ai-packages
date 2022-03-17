using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Josephus.AIPackages
{
    //You could add your own here if you want
    public enum MovementSpeed
    {
        Walk,
        Run
    }

    public abstract class AIPackage : ScriptableObject
    {
        [SerializeField] MovementSpeed _movementSpeed;
        [SerializeField] bool _mustComplete;

        public MovementSpeed MovementSpeed => _movementSpeed;
        public bool MustComplete => _mustComplete;

        public abstract bool HasCompleted(AI Ai);
        public abstract bool IsConditionMet(AI Ai);
        public abstract void OnUpdate(AI Ai);
        public abstract void OnStart(AI Ai);
        public abstract void OnFinish(AI Ai);
    }
}