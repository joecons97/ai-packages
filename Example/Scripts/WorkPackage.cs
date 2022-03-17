using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Josephus.AIPackages.Example
{
    [CreateAssetMenu(menuName = "Josephus/AI-Packages/WorkPackage")]
    public class WorkPackage : AIPackage
    {
        public float StartTime;
        public float EndTime;
        public string LocationGameObjectName;

        public override void OnStart(AI Ai)
        {
            Ai.Agent.SetDestination(GameObject.Find(LocationGameObjectName).transform.position);
        }

        public override void OnFinish(AI Ai)
        { 
        }

        public override void OnUpdate(AI Ai)
        {
        }

        public override bool HasCompleted(AI Ai)
        {
            return Ai.Agent.remainingDistance <= Ai.Agent.stoppingDistance;
        }

        public override bool IsConditionMet(AI Ai)
        {
            if (EndTime < StartTime)
            {
                return TimeOfDay.Instance.DayTime > StartTime && TimeOfDay.Instance.DayTime > EndTime;
            }
            else
            {
                return TimeOfDay.Instance.DayTime > StartTime && TimeOfDay.Instance.DayTime < EndTime;
            }
        }
    }
}