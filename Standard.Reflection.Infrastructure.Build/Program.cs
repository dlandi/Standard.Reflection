// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace Standard.Reflection.Infrastructure.Build
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adoNetClient = new ADotNetClient();

            var gitHubPipeline = new GithubPipeline
            {
                Name = "Standard.Reflection Build",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.WindowsLatest,

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Pulling Code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Installing .NET",

                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    DotNetVersion = "7.0.203"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Solution"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };

            string gitHubDirectoryPath = "../../../../.github";
            string directoryPath = gitHubDirectoryPath + "/workflows";
            string filename = "dotnet.yml";
            string fullPath = Path.Combine(directoryPath, filename);

            DirectoryInfo directory = Directory.CreateDirectory(gitHubDirectoryPath);
            directory.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            Directory.CreateDirectory(directoryPath);

            adoNetClient.SerializeAndWriteToFile(
                adoPipeline: gitHubPipeline,
                path: fullPath);
        }
    }
}
