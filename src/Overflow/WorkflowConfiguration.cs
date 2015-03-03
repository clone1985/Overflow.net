using System.Collections.Generic;

namespace Overflow
{
    public class WorkflowConfiguration<TOperation> : WorkflowConfiguration
        where TOperation : IOperation
    {
        public override IOperation CreateOperation()
        {
            return (TOperation)Operation.Create<TOperation>(this);
        }
    }

    public abstract class WorkflowConfiguration
    {
        public IOperationResolver Resolver { get; set; }
        public IWorkflowLogger Logger { get; set; }
        public IList<IOperationBehaviorFactory> BehaviorFactories { get; private set; }

        public abstract IOperation CreateOperation();

        protected WorkflowConfiguration()
        {
            BehaviorFactories = new List<IOperationBehaviorFactory>();
        }

        public WorkflowConfiguration WithResolver(IOperationResolver resolver)
        {
            Resolver = resolver;

            return this;
        }

        public WorkflowConfiguration WithLogger(IWorkflowLogger logger)
        {
            Logger = logger;

            return this;
        }

        public WorkflowConfiguration WithBehaviorFactory(IOperationBehaviorFactory factory)
        {
            BehaviorFactories.Add(factory);

            return this;
        }
    }
}
