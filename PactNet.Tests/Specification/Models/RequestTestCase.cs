﻿using PactNet.Mocks.MockHttpService.Comparers;
using PactNet.Mocks.MockHttpService.Models;

namespace PactNet.Tests.Specification.Models
{
    public class RequestTestCase : IVerifiable
    {
        private readonly IPactProviderServiceRequestComparer _requestComparer;

        public bool Match { get; set; }
        public string Comment { get; set; }
        public PactProviderServiceRequest Expected { get; set; }
        public PactProviderServiceRequest Actual { get; set; }

        public RequestTestCase()
        {
            _requestComparer = new PactProviderServiceRequestComparer();
        }

        public bool Verified()
        {
            try
            {
                _requestComparer.Compare(Expected, Actual);
            }
            catch (CompareFailedException)
            {
                if (Match)
                {
                    return false;
                }
                return true;
            }

            if (!Match)
            {
                return false;
            }

            return true;
        }
    }
}