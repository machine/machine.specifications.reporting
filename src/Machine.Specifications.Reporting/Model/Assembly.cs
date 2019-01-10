﻿using System.Collections.Generic;
using System.Linq;
using Machine.Specifications.Runner.Utility;

namespace Machine.Specifications.Reporting.Model
{
    public class Assembly : SpecificationContainer, ISpecificationNode
    {
        readonly string _name;
        readonly IEnumerable<Concern> _concerns;
        readonly int _totalConerns;
        readonly int _totalContexts;
        readonly string _capturedOutput;

        public Assembly(string name, IEnumerable<Concern> concerns)
            : base(concerns.Cast<SpecificationContainer>())
        {
            _name = name;
            _concerns = concerns.OrderBy(x => x.Name);
            _totalConerns = concerns.Count();
            _totalContexts = concerns.Sum(x => x.TotalContexts);
        }

        public Assembly(AssemblyInfo assembly, IEnumerable<Concern> concerns)
            : this(assembly.Name, concerns)
        {
            _capturedOutput = assembly.CapturedOutput;
        }

        public string Name
        {
            get { return _name; }
        }

        public string CapturedOutput
        {
            get { return _capturedOutput; }
        }

        public IEnumerable<Concern> Concerns
        {
            get { return _concerns; }
        }

        public int TotalConcerns
        {
            get { return _totalConerns; }
        }

        public int TotalContexts
        {
            get { return _totalContexts; }
        }

        public void Accept(ISpecificationVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerable<ISpecificationNode> Children
        {
            get { return _concerns.Cast<ISpecificationNode>(); }
        }
    }
}
