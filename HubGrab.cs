﻿using System;
using GitGrabber.Models;
using GitGrabber.Components;

namespace GitGrabber
{
    public class GitGrabConnection
    {
        private GithubConnection connection = new GithubConnection() {
            connection_success = false,
            connection_latency = 0
        };
        public bool Connect() {
            connection = ConnectionWorker.Connect();
            return connection.connection_success;
        }

        public GithubApiResponse GithubApi() {
            if(connection.connection_success) {
                return ConnectionWorker.Fetch();
            }
            else {
                return new GithubApiResponse();
            }
        }
    }
}