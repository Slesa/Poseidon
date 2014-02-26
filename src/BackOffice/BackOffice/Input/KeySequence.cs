using System;
using System.Text;
using System.Windows.Input;

namespace Poseidon.BackOffice.Input
{
    /// <summary>
    /// Class used to store multi-key gesture data.
    /// </summary>
    public class KeySequence
    {

        /// <summary>
        ///   Initializes a new instance of the <see cref="KeySequence" /> class.
        /// </summary>
        public KeySequence(ModifierKeys modifiers, params Key[] keys)
        {
            if (keys == null)
                throw new ArgumentNullException("keys");
            if (keys.Length < 1)
                throw new ArgumentException("At least 1 key should be provided", "keys");

            _keys = new Key[keys.Length];
            keys.CopyTo(_keys, 0);
            _modifiers = modifiers;
        }

        readonly Key[] _keys;

        /// <summary>
        /// Gets the sequence of keys.
        /// </summary>
        /// <value> The sequence of keys. </value>
        public Key[] Keys
        {
            get { return _keys; }
        }

        readonly ModifierKeys _modifiers;

        /// <summary>
        /// Gets the modifiers to be applied to the sequence.
        /// </summary>
        /// <value> The modifiers to be applied to the sequence. </value>
        public ModifierKeys Modifiers
        {
            get { return _modifiers; }
        }

        /// <summary>
        ///   Returns a <see cref="string" /> that represents the current <see cref="object" /> .
        /// </summary>
        /// <returns> A <see cref="string" /> that represents the current <see cref="object" /> . </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            if (_modifiers != ModifierKeys.None)
            {
                if ((_modifiers & ModifierKeys.Control) != ModifierKeys.None)
                    builder.Append("Ctrl+");
                if ((_modifiers & ModifierKeys.Alt) != ModifierKeys.None)
                    builder.Append("Alt+");
                if ((_modifiers & ModifierKeys.Shift) != ModifierKeys.None)
                    builder.Append("Shift+");
                if ((_modifiers & ModifierKeys.Windows) != ModifierKeys.None)
                    builder.Append("Windows+");
            }

            builder.Append(_keys[0]);
            for (var i = 1; i < _keys.Length; i++)
                builder.Append("+" + _keys[i]);

            return builder.ToString();
        }
    }
}