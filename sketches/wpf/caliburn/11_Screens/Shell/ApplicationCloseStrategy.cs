using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using _11_Screens.Framework;

namespace _11_Screens.Shell 
{
    public class ApplicationCloseStrategy : ICloseStrategy<IWorkspace> 
    {
        IEnumerator<IWorkspace> _enumerator;
        bool _finalResult;
        Action<bool, IEnumerable<IWorkspace>> _callback;

        public void Execute(IEnumerable<IWorkspace> toClose, Action<bool, IEnumerable<IWorkspace>> callback) 
        {
            _enumerator = toClose.GetEnumerator();
            _callback = callback;
            _finalResult = true;

            Evaluate(_finalResult);
        }

        void Evaluate(bool result)
        {
            _finalResult = _finalResult && result;

            if (!_enumerator.MoveNext() || !result)
                _callback(_finalResult, new List<IWorkspace>());
            else
            {
                var current = _enumerator.Current;
                var conductor = current as IConductor;
                if (conductor != null)
                {
                    var tasks = conductor.GetChildren()
                        .OfType<IHaveShutdownTask>()
                        .Select(x => x.GetShutdownTask())
                        .Where(x => x != null);

                    var sequential = new SequentialResult(tasks.GetEnumerator());
                    sequential.Completed += (s, e) =>
                        {
                            if (!e.WasCancelled)
                                Evaluate(!e.WasCancelled);
                        };
                    sequential.Execute(new ActionExecutionContext());
                }
                else Evaluate(true);
            }
        }
    }
}