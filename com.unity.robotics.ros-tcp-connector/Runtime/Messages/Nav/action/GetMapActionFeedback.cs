using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#else
using RosMessageTypes.UniqueIdentifier;
#endif

namespace RosMessageTypes.Nav
{
    public class GetMapActionFeedback : ActionFeedback<GetMapFeedback>
    {
        public const string k_RosMessageName = "nav_msgs/GetMapActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public GetMapActionFeedback() : base()
        {
            this.feedback = new GetMapFeedback();
        }

#if !ROS2
        public GetMapActionFeedback(HeaderMsg header, GoalStatusMsg status, GetMapFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
#else
        public GetMapActionFeedback(UUIDMsg goal_id, GetMapFeedback feedback) : base(goal_id)
        {
            this.feedback = feedback;
        }
#endif
        public static GetMapActionFeedback Deserialize(MessageDeserializer deserializer) => new GetMapActionFeedback(deserializer);

        GetMapActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = GetMapFeedback.Deserialize(deserializer);
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
