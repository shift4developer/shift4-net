﻿using Xunit;
using Xunit.Sdk;
using Shift4;
using Shift4.Exception;
using Shift4.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Integration
{
    public class IntegrationTest
    {
        protected Shift4Gateway _gateway;
        protected Random _random=new Random();


        public IntegrationTest()
        {
            var configProvider = new TestConfigurationProvider();
            var mimeMapper = new FileExtensionToMimeMapper();
            var httpClient = new Shift4.Internal.HttpClient();
            var apiClient = new ApiClient(httpClient,configProvider, mimeMapper);
            var signService = new SignService(configProvider);
            _gateway = new Shift4Gateway(apiClient, configProvider, signService);
        }

        protected void HandleApiException(Shift4Exception exc)
        {
            Fail("Shift4Exception  was thrown with message: {0},code:{1},request type:{2},action:{3}",
                          exc.Error.Message,
                          exc.Error.Code.HasValue ? exc.Error.Code.Value.ToString() : "no code",
                          exc.RequestType,
                          exc.RequestAction
            );
        }

        protected void Fail(string message, params object[] args) 
        {
            throw new XunitException(string.Format(message, args));
        }

        protected string CorrectCardExpiryYear
        {
            get
            {
                return (DateTime.Today.Year + 1).ToString();
            }
        }

        protected async Task WaitUntil(Func<Task<bool>> condition, int timeout, int frequency = 100)
        {
            var waitTask = Task.Run(async () =>
            {
                while (!(await condition())) 
                {
                    await Task.Delay(frequency);
                }
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout))) 
                throw new TimeoutException();
        }

    }
}
