using System.Collections.Generic;
using System.Linq;
using Machine.Specifications.Runner.Utility;

namespace Machine.Specifications.Reporting.Model
{
    public abstract class SpecificationContainer
    {
        readonly int _totalSpecifications;
        readonly int _passingSpecifications;
        readonly int _failingSpecifications;
        readonly int _notImplementedSpecifications;
        readonly int _ignoredSpecifications;

        protected SpecificationContainer(IEnumerable<Specification> specifications)
        {
            _totalSpecifications = specifications.Count();
            _passingSpecifications = specifications.Count(x => x.Status == Status.Passing);
            _failingSpecifications = specifications.Count(x => x.Status == Status.Failing);
            _notImplementedSpecifications = specifications.Count(x => x.Status == Status.NotImplemented);
            _ignoredSpecifications = specifications.Count(x => x.Status == Status.Ignored);
        }

        protected SpecificationContainer(IEnumerable<SpecificationContainer> specificationContainers)
        {
            _totalSpecifications = specificationContainers.Sum(x => x.TotalSpecifications);
            _passingSpecifications = specificationContainers.Sum(x => x.PassingSpecifications);
            _failingSpecifications = specificationContainers.Sum(x => x.FailingSpecifications);
            _notImplementedSpecifications = specificationContainers.Sum(x => x.NotImplementedSpecifications);
            _ignoredSpecifications = specificationContainers.Sum(x => x.IgnoredSpecifications);
        }

        public int TotalSpecifications
        {
            get { return _totalSpecifications; }
        }

        public int PassingSpecifications
        {
            get { return _passingSpecifications; }
        }

        public int FailingSpecifications
        {
            get { return _failingSpecifications; }
        }

        public int NotImplementedSpecifications
        {
            get { return _notImplementedSpecifications; }
        }

        public int IgnoredSpecifications
        {
            get { return _ignoredSpecifications; }
        }
    }
}