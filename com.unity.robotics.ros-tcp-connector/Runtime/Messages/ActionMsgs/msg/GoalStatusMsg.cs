// ROS2 action_msgs/GoalStatus message
// This message is used in ROS2 for action goal status reporting
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.ActionMsgs
{
    [Serializable]
    public class GoalStatusMsg : Message
    {
        public const string k_RosMessageName = "action_msgs/GoalStatus";
        public override string RosMessageName => k_RosMessageName;

        // Goal information (contains goal_id and stamp)
        public GoalInfoMsg goal_info;
        
        // Goal status value
        public sbyte status;

        // Indicates status has not been properly set.
        public const sbyte STATUS_UNKNOWN = 0;
        // The goal has been accepted and is awaiting execution.
        public const sbyte STATUS_ACCEPTED = 1;
        // The goal is currently being executed by the action server.
        public const sbyte STATUS_EXECUTING = 2;
        // The client has requested that the goal be canceled and the action server has
        // accepted the cancel request.
        public const sbyte STATUS_CANCELING = 3;
        // The goal was achieved successfully by the action server.
        public const sbyte STATUS_SUCCEEDED = 4;
        // The goal was canceled after an external request from an action client.
        public const sbyte STATUS_CANCELED = 5;
        // The goal was terminated by the action server without an external request.
        public const sbyte STATUS_ABORTED = 6;

        public GoalStatusMsg()
        {
            this.goal_info = new GoalInfoMsg();
            this.status = 0;
        }

        public GoalStatusMsg(GoalInfoMsg goal_info, sbyte status)
        {
            this.goal_info = goal_info;
            this.status = status;
        }

        public static GoalStatusMsg Deserialize(MessageDeserializer deserializer) => new GoalStatusMsg(deserializer);

        private GoalStatusMsg(MessageDeserializer deserializer)
        {
            this.goal_info = GoalInfoMsg.Deserialize(deserializer);
            deserializer.Read(out this.status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.goal_info);
            serializer.Write(this.status);
        }

        public override string ToString()
        {
            return "GoalStatusMsg: " +
            "\ngoal_info: " + goal_info.ToString() +
            "\nstatus: " + status.ToString();
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
}
