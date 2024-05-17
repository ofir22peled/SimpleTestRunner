﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRunner.Interfaces;

namespace TestRunner
{
    public class TestsExecuter : ITestsExecuter
    {
        private readonly ITestsSummary _summary;
        private readonly IReporter _reporter;
        private readonly IReadOnlyCollection<MethodInfo> _methodInfos;

        public TestsExecuter(IReadOnlyCollection<MethodInfo> methodInfos, IReporter reporter, ITestsSummary summary)
        {
            _methodInfos = methodInfos;
            _summary = summary;
            _reporter = reporter;
        }

        public void ExecuteTests(IReadOnlyCollection<MethodInfo> methodInfos)
        {
            foreach (MethodInfo test in methodInfos)
            {
                ExecuteTest(test, Activator.CreateInstance(test.DeclaringType));
            }
        }

        private void ExecuteTest(MethodInfo method, object instance)
        {
            if (instance == null)
            {
                _reporter.InstanceCreationFailed(method.DeclaringType.Name);
                _summary.AddFailureResult(method.Name);
            }
            else
            {
                try
                {
                    method.Invoke(instance, parameters: null);
                    _reporter.TestPassed(method.Name);
                    _summary.AddSuccessResult(method.Name);
                }
                catch (TargetInvocationException ex)
                {
                    _reporter.TestFailed(method.Name, ex.InnerException?.Message ?? ex.Message);
                    _summary.AddFailureResult(method.Name);
                }
            }
        }
    }
}