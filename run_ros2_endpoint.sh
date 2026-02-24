#!/bin/bash
# Run ROS2 TCP Endpoint server

set -e

# Default values
ROS_IP=${ROS_IP:-"0.0.0.0"}
ROS_TCP_PORT=${ROS_TCP_PORT:-10000}

echo "Starting ROS2 TCP Endpoint..."
echo "ROS_IP: $ROS_IP"
echo "ROS_TCP_PORT: $ROS_TCP_PORT"

# Source ROS2 Humble
if [ -f "/opt/ros/humble/setup.bash" ]; then
    source /opt/ros/humble/setup.bash
else
    echo "Error: ROS2 Humble not found at /opt/ros/humble/setup.bash"
    exit 1
fi

# Source workspace if it exists
if [ -f "$HOME/ros2_ws/install/setup.bash" ]; then
    source ~/ros2_ws/install/setup.bash
fi

# Run the endpoint
ros2 run ros_tcp_endpoint default_server_endpoint --ros-ip $ROS_IP --ros-port $ROS_TCP_PORT
