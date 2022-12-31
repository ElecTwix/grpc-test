// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcGreeterClient {
  public static partial class StreamService
  {
    static readonly string __ServiceName = "electwix.StreamService";

    static readonly grpc::Marshaller<global::GrpcGreeterClient.Request> __Marshaller_electwix_Request = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcGreeterClient.Request.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcGreeterClient.Response> __Marshaller_electwix_Response = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcGreeterClient.Response.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcGreeterClient.Request, global::GrpcGreeterClient.Response> __Method_FetchResponse = new grpc::Method<global::GrpcGreeterClient.Request, global::GrpcGreeterClient.Response>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "FetchResponse",
        __Marshaller_electwix_Request,
        __Marshaller_electwix_Response);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcGreeterClient.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for StreamService</summary>
    public partial class StreamServiceClient : grpc::ClientBase<StreamServiceClient>
    {
      /// <summary>Creates a new client for StreamService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public StreamServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for StreamService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public StreamServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected StreamServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected StreamServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::GrpcGreeterClient.Response> FetchResponse(global::GrpcGreeterClient.Request request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return FetchResponse(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::GrpcGreeterClient.Response> FetchResponse(global::GrpcGreeterClient.Request request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_FetchResponse, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override StreamServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new StreamServiceClient(configuration);
      }
    }

  }
}
#endregion
