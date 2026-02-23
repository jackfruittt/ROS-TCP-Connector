using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#else
using RosMessageTypes.UniqueIdentifier;
#endif

namespace RosMessageTypes.Tf2
{
    public class LookupTransformActionGoal : ActionGoal<LookupTransformGoal>
    {
        public const string k_RosMessageName = "tf2_msgs/LookupTransformActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public LookupTransformActionGoal() : base()
        {
            this.goal = new LookupTransformGoal();
        }

#if !ROS2
        public LookupTransformActionGoal(HeaderMsg header, GoalIDMsg goal_id, LookupTransformGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
#else
        public LookupTransformActionGoal(UUIDMsg goal_id, LookupTransformGoal goal) : base(goal_id)
        {
            this.goal = goal;
        }
#endif
        public static LookupTransformActionGoal Deserialize(MessageDeserializer deserializer) => new LookupTransformActionGoal(deserializer);

        LookupTransformActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = LookupTransformGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
#if !ROS2
            serializer.Write(this.header);
#endif
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
        }

    }
}
