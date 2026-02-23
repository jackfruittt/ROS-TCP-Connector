using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
#if !ROS2
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;
#else
using RosMessageTypes.UniqueIdentifier;
#endif

namespace RosMessageTypes.ObjectRecognition
{
    public class ObjectRecognitionActionFeedback : ActionFeedback<ObjectRecognitionFeedback>
    {
        public const string k_RosMessageName = "object_recognition_msgs-master/ObjectRecognitionActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public ObjectRecognitionActionFeedback() : base()
        {
            this.feedback = new ObjectRecognitionFeedback();
        }

#if !ROS2
        public ObjectRecognitionActionFeedback(HeaderMsg header, GoalStatusMsg status, ObjectRecognitionFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
#else
        public ObjectRecognitionActionFeedback(UUIDMsg goal_id, ObjectRecognitionFeedback feedback) : base(goal_id)
        {
            this.feedback = feedback;
        }
#endif
        public static ObjectRecognitionActionFeedback Deserialize(MessageDeserializer deserializer) => new ObjectRecognitionActionFeedback(deserializer);

        ObjectRecognitionActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = ObjectRecognitionFeedback.Deserialize(deserializer);
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
