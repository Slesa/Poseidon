using System;

namespace Poseidon.Common.Wpf.Helpers
{
    /// <summary>
    /// Weak event handler implementation.
    /// </summary>
    /// <typeparam name="TInstance">The type of the object with the actual handler.</typeparam>
    /// <typeparam name="TSender">Type of the event sender.</typeparam>
    /// <typeparam name="TEventArgs">Type of the event arguments.</typeparam>
    public class WeakEventHandler<TInstance, TSender, TEventArgs>
        where TInstance : class
    {
        readonly WeakReference _instanceReference;
        readonly Action<TInstance, TSender, TEventArgs> _handlerAction;
        Action<WeakEventHandler<TInstance, TSender, TEventArgs>> _detachAction;

        /// <summary>
        /// Initializes a new instance of the WeakEventHandler{TInstance, TSender, TEventArgs} class.
        /// </summary>
        /// <param name="instance">The object with the actual handler, to which a weak reference will be held.</param>
        /// <param name="handlerAction">An action to invoke the actual handler.</param>
        /// <param name="detachAction">An action to detach the weak handler from the event.</param>
        public WeakEventHandler(
            TInstance instance,
            Action<TInstance, TSender, TEventArgs> handlerAction,
            Action<WeakEventHandler<TInstance, TSender, TEventArgs>> detachAction)
        {
            _instanceReference = new WeakReference(instance);
            _handlerAction = handlerAction;
            _detachAction = detachAction;
        }

        /// <summary>
        /// Removes the weak event handler from the event.
        /// </summary>
        public void Detach()
        {
            if (_detachAction == null) return;
            _detachAction(this);
            _detachAction = null;
        }

        /// <summary>
        /// Invokes the handler action.
        /// </summary>
        /// <remarks>
        /// This method must be added as the handler to the event.
        /// </remarks>
        /// <param name="sender">The event source object.</param>
        /// <param name="e">The event arguments.</param>
        public void OnEvent(TSender sender, TEventArgs e)
        {
            var instance = _instanceReference.Target as TInstance;
            if (instance != null)
            {
                if (_handlerAction != null)
                {
                    _handlerAction((TInstance) _instanceReference.Target, sender, e);
                }
            }
            else
            {
                Detach();
            }
        }
    }
}