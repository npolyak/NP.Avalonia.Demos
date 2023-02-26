using NP.Grpc.CommonRelayInterfaces;

namespace DockableAppImplantsDemo
{
    internal class GrpcConfig : IGrpcConfig
    {
        public string ServerName => "localhost";

        public int Port => 5051;
    }
}
