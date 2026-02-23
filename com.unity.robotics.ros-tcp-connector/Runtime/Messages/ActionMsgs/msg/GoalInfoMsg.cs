// ROS2 action_msgs/GoalInfo message
// This message is used in ROS2 for action goal information
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.UniqueIdentifier;
using RosMessageTypes.BuiltinInterfaces;

namespace RosMessageTypes.ActionMsgs
{
    [Serializable]
    public class GoalInfoMsg : Message
    {
        public const string k_RosMessageName = "action_msgs/GoalInfo";
        public override string RosMessageName => k_RosMessageName;

        // Goal ID
        public UUIDMsg goal_id;
        // Time when the goal was accepted
        public TimeMsg stamp;

        public GoalInfoMsg()
        {
            this.goal_id = new UUIDMsg();
            this.stamp = new TimeMsg();
        }

        public GoalInfoMsg(UUIDMsg goal_id, TimeMsg stamp)
        {
            this.goal_id = goal_id;
            this.stamp = stamp;
        }

        public static GoalInfoMsg Deserialize(MessageDeserializer deserializer) => new GoalInfoMsg(deserializer);

        private GoalInfoMsg(MessageDeserializer deserializer)
        {
            this.goal_id = UUIDMsg.Deserialize(deserializer);
            this.stamp = TimeMsg.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.goal_id);
            serializer.Write(this.stamp);
        }

        public override string ToString()
        {
            return "GoalInfoMsg: " +
            "\ngoal_id: " + goal_id.ToString() +
            "\nstamp: " + stamp.ToString();
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
