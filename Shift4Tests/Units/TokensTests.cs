﻿using Xunit;
using Shift4.Request;
using Shift4.Response;
using Shift4Tests.ModelBuilders;
using Shift4Tests.Units.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Tests.Units
{
        public class TokensTests :BaseUnitTestsSet
    {
        TokenRequestBuilder _tokenRequestBuilder=new TokenRequestBuilder();

        [Fact]
        public async Task CreateTokenTest()
        {
            var requestTester = GetRequestTester();
            var tokenRequest = _tokenRequestBuilder.Build();
            await requestTester.TestMethod<Token>(
                async (api) =>
                {
                    await api.CreateToken(tokenRequest);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Post,
                    Action = "tokens",
                    Parameter = tokenRequest
                }
            );
        }

        [Fact]
        public async Task RetrieveTokenTest()
        {
            var requestTester = GetRequestTester();
            var tokenId = "1";
            await requestTester.TestMethod<Token>(
                async (api) =>
                {
                    await api.RetrieveToken(tokenId);
                },
                new RequestDescriptor()
                {
                    Method = HttpMethod.Get,
                    Action = string.Format("tokens/{0}", tokenId),
                    Parameter = null
                }
            );
        }


        //retrieve

    }
}
