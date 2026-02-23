// ROS2 action_msgs/CancelGoal service
// This service is used in ROS2 for canceling action goals
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.ActionMsgs
{
    [Serializable]
    public class CancelGoalRequest : Message
    {
        public const string k_RosMessageName = "action_msgs/CancelGoal_Request";
        public override string RosMessageName => k_RosMessageName;

        // Goal info describing the goals to cancel.
        // If the stamp is zero, all goals with the goal_id are canceled.
        // If the goal_id is all zeros, all goals before the stamp are canceled.
        // If both are zero, all goals are canceled.
        public GoalInfoMsg goal_info;

        public CancelGoalRequest()
        {
            this.goal_info = new GoalInfoMsg();
        }

        public CancelGoalRequest(GoalInfoMsg goal_info)
        {
            this.goal_info = goal_info;
        }

        public static CancelGoalRequest Deserialize(MessageDeserializer deserializer) => new CancelGoalRequest(deserializer);

        private CancelGoalRequest(MessageDeserializer deserializer)
        {
            this.goal_info = GoalInfoMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.goal_info);
        }

        public override string ToString()
        {
            return "CancelGoalRequest: " +
            "\ngoal_info: " + goal_info.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }

    [Serializable]
    public class CancelGoalResponse : Message
    {
        public const string k_RosMessageName = "action_msgs/CancelGoal_Response";
        public override string RosMessageName => k_RosMessageName;

        // Return code indicating the result of the cancel request
        public sbyte return_code;

        // None of the goals were canceled
        public const sbyte ERROR_NONE = 0;
        // One or more goals were rejected because they do not exist
        public const sbyte ERROR_REJECTED = 1;
        // One or more goals were rejected because they do not belong to the caller
        public const sbyte ERROR_UNKNOWN_GOAL_ID = 2;
        // One or more goals cannot be canceled because they are already in terminal state
        public const sbyte ERROR_GOAL_TERMINATED = 3;

        // Goals that were canceled by this service call
        public GoalInfoMsg[] goals_canceling;

        public CancelGoalResponse()
        {
            this.return_code = 0;
            this.goals_canceling = new GoalInfoMsg[0];
        }

        public CancelGoalResponse(sbyte return_code, GoalInfoMsg[] goals_canceling)
        {
            this.return_code = return_code;
            this.goals_canceling = goals_canceling;
        }

        public static CancelGoalResponse Deserialize(MessageDeserializer deserializer) => new CancelGoalResponse(deserializer);

        private CancelGoalResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.return_code);
            deserializer.Read(out this.goals_canceling, GoalInfoMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.return_code);
            serializer.WriteLength(this.goals_canceling);
            serializer.Write(this.goals_canceling);
        }

        public override string ToString()
        {
            return "CancelGoalResponse: " +
            "\nreturn_code: " + return_code.ToString() +
            "\ngoals_canceling: " + System.String.Join(", ", goals_canceling.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}
