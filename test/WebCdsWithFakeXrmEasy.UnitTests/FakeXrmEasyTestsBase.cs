using FakeXrmEasy.Abstractions;
using FakeXrmEasy.Middleware;
using Microsoft.Xrm.Sdk;

namespace WebCdsWithFakeXrmEasy.UnitTests
{
    public class FakeXrmEasyTestsBase
    {
        protected readonly IOrganizationService _service;
        protected readonly IXrmFakedContext _context;

        public FakeXrmEasyTestsBase()
        {
            _context = XrmFakedContextFactory.New();
            _service = _context.GetOrganizationService();
        }
    }
}