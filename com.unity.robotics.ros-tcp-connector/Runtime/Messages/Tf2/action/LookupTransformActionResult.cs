using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#endif

namespace RosMessageTypes.Tf2
{
    public class LookupTransformActionResult : ActionResult<LookupTransformResult>
    {
        public const string k_RosMessageName = "tf2_msgs/LookupTransformActionResult";
        public override string RosMessageName => k_RosMessageName;


        public LookupTransformActionResult() : base()
        {
            this.result = new LookupTransformResult();
        }

#if !ROS2
        public LookupTransformActionResult(HeaderMsg header, GoalStatusMsg status, LookupTransformResult result) : base(header, status)
        {
            this.result = result;
        }
#else
        public LookupTransformActionResult(sbyte status, LookupTransformResult result) : base(status)
        {
            this.result = result;
        }
#endif
        public static LookupTransformActionResult Deserialize(MessageDeserializer deserializer) => new LookupTransformActionResult(deserializer);

        LookupTransformActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = LookupTransformResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
#if !ROS2
            serializer.Write(this.header);
#endif
            serializer.Write(this.status);
            serializer.Write(this.result);
        }

    }
}
