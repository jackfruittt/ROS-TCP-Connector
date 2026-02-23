// ROS2 unique_identifier_msgs/UUID message
// This message is only used in ROS2 for action goal identification
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.UniqueIdentifier
{
    [Serializable]
    public class UUIDMsg : Message
    {
        public const string k_RosMessageName = "unique_identifier_msgs/UUID";
        public override string RosMessageName => k_RosMessageName;

        // A universally unique identifier (UUID).
        // http://en.wikipedia.org/wiki/Universally_unique_identifier
        // 128 bit UUID represented as a byte array of length 16
        public byte[] uuid;

        public UUIDMsg()
        {
            this.uuid = new byte[16];
        }

        public UUIDMsg(byte[] uuid)
        {
            this.uuid = uuid;
        }

        /// <summary>
        /// Create a UUID message from a System.Guid
        /// </summary>
        public UUIDMsg(Guid guid)
        {
            this.uuid = guid.ToByteArray();
        }

        /// <summary>
        /// Generate a new random UUID
        /// </summary>
        public static UUIDMsg Generate()
        {
            return new UUIDMsg(Guid.NewGuid());
        }

        /// <summary>
        /// Convert to System.Guid
        /// </summary>
        public Guid ToGuid()
        {
            return new Guid(uuid);
        }

        public static UUIDMsg Deserialize(MessageDeserializer deserializer) => new UUIDMsg(deserializer);

        private UUIDMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.uuid, sizeof(byte), 16);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.uuid);
        }

        public override string ToString()
        {
            return "UUIDMsg: " +
            "\nuuid: " + ToGuid().ToString();
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
