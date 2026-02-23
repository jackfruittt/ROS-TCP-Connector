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
    public class LookupTransformActionFeedback : ActionFeedback<LookupTransformFeedback>
    {
        public const string k_RosMessageName = "tf2_msgs/LookupTransformActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public LookupTransformActionFeedback() : base()
        {
            this.feedback = new LookupTransformFeedback();
        }

#if !ROS2
        public LookupTransformActionFeedback(HeaderMsg header, GoalStatusMsg status, LookupTransformFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
#else
        public LookupTransformActionFeedback(UUIDMsg goal_id, LookupTransformFeedback feedback) : base(goal_id)
        {
            this.feedback = feedback;
        }
#endif
        public static LookupTransformActionFeedback Deserialize(MessageDeserializer deserializer) => new LookupTransformActionFeedback(deserializer);

        LookupTransformActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = LookupTransformFeedback.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
#if !ROS2
            serializer.Write(this.header);
            serializer.Write(this.status);
#else
            serializer.Write(this.goal_id);
#endif
            serializer.Write(this.feedback);
        }

    }
}
