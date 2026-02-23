using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#endif

namespace RosMessageTypes.Nav
{
    public class GetMapActionResult : ActionResult<GetMapResult>
    {
        public const string k_RosMessageName = "nav_msgs/GetMapActionResult";
        public override string RosMessageName => k_RosMessageName;


        public GetMapActionResult() : base()
        {
            this.result = new GetMapResult();
        }

#if !ROS2
        public GetMapActionResult(HeaderMsg header, GoalStatusMsg status, GetMapResult result) : base(header, status)
        {
            this.result = result;
        }
#else
        public GetMapActionResult(sbyte status, GetMapResult result) : base(status)
        {
            this.result = result;
        }
#endif
        public static GetMapActionResult Deserialize(MessageDeserializer deserializer) => new GetMapActionResult(deserializer);

        GetMapActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = GetMapResult.Deserialize(deserializer);
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
