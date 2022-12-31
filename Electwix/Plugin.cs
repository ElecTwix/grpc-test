using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using MEC;
using Grpc;
using Hints;
using PluginAPI.Enums;
using PluginAPI.Events;
using GrpcGreeterClient;
using UnityEngine;
using Console = GameCore.Console;


namespace Electwix
{
    public class Plugin
    {
        [PluginEntryPoint("ElecTwix Custom", "0.1", "Doing things", "electwix")]
        void Enabled()
        {

            EventManager.RegisterEvents(this);
            Timing.RunCoroutine(connect());
 
        }
        
        [PluginEvent(ServerEventType.RoundStart)]
        void OnRoundStarted()
        {
            Timing.RunCoroutine(connect());
        }
        
        [PluginEvent(ServerEventType.PlayerJoined)]
        void OnPlayerJoin(Player player)
        {
            Timing.RunCoroutine(JoiNCallEnumerator(player));
        }

        public IEnumerator<float> JoiNCallEnumerator(Player player)
        {
            player.SendBroadcast("Test", 10, Broadcast.BroadcastFlags.Normal, false);
            yield return Timing.WaitForSeconds(1f);
        }

        public IEnumerator<float> connect()
        {
            Console.AddLog("Start Connect", Color.magenta, false, Console.ConsoleLogType.Log);
            yield return Timing.WaitForSeconds(1f);
            try
            {
                Console.AddLog("connection Try", Color.magenta, false, Console.ConsoleLogType.Log);

                Console.AddLog("pase 1", Color.magenta, false, Console.ConsoleLogType.Log);

                var str = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                Console.AddLog("pase 2 " + str, Color.magenta, false, Console.ConsoleLogType.Log);

                var cert = File.ReadAllText(str + "/ssl/my-public-key-cert.pem");

                Console.AddLog("pase 3", Color.magenta, false, Console.ConsoleLogType.Log);

                var credentials = new SslCredentials(cert);

                Console.AddLog("pase 4", Color.magenta, false, Console.ConsoleLogType.Log);
                
                var channel = new Channel("localhost:50080", credentials);

                Console.AddLog("pase 5", Color.magenta, false, Console.ConsoleLogType.Log);

                var client = new StreamService.StreamServiceClient(channel);

                Console.AddLog("pase 6", Color.magenta, false, Console.ConsoleLogType.Log);

                ServerHandler(client, channel);
            }
            catch(Exception ex)
            {
                Console.AddLog(" \n Error Msg: \n", Color.red, false, Console.ConsoleLogType.Log);
                Console.AddLog(ex.Message, Color.red, false, Console.ConsoleLogType.Log);
                //Console.AddLog(ex.TargetSite.Name, Color.red, false, Console.ConsoleLogType.Log);
                Console.AddLog("Here: " + ex.ToString(), Color.red, false, Console.ConsoleLogType.Log);
                //Console.AddLog(ex.HResult.ToString(), Color.red, false, Console.ConsoleLogType.Log);
            }

        }
        
        private static async void ServerHandler(StreamService.StreamServiceClient client, Channel chn)
        {
            for (;;)
            {
                bool crashed = await GetDataStreaming(client, chn);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Console.AddLog("Restarting", Color.green, false, Console.ConsoleLogType.Log);
            }
            return;
        }
        
        private static async Task<bool> GetDataStreaming(StreamService.StreamServiceClient client, Channel chn)
        {
            CancellationToken ok = new CancellationToken();
            AsyncServerStreamingCall<Response> response = client.FetchResponse(new Request { Id = 10 }, null, null, ok);
            try
            {
                while (await response.ResponseStream.MoveNext(ok))
                {
                    Response current = response.ResponseStream.Current;
                    foreach (var ply in PluginAPI.Core.Player.GetPlayers())
                    {
                        Console.AddLog(current.Result, Color.green, false, Console.ConsoleLogType.Log);
                        ply.SendBroadcast(current.Result, 10);
                    }
                }
            }
            catch (Exception ex)
            {
                return true; 
            }

            return false;
        }
    }
}