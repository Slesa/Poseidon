using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Prolog;
using Prolog.Code;

namespace Tutorial
{
    public class PrologRun
    {
        readonly string _fileName;
        readonly string _queryHint;

        public PrologRun(string fileName, string queryHint)
        {
            _fileName = fileName;
            _queryHint = queryHint;
        }

        public void Run()
        {
            var program = new Prolog.Program();
            var content = File.ReadAllText(_fileName);
            var codeSentences = GetCodeSentences(content);
            if (codeSentences == null) return;

            foreach (var sentence in codeSentences)
                program.Add(sentence);

            PrologMachine lastMachine = null;
            while (true)
            {
                Console.Write("Hint.: "+_queryHint);
                Console.Write("Query: ");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) return;

                if (input.ToLower() == "n" && lastMachine!=null)
                {
                    lastMachine.RunToBacktrack();
                    continue;
                }

                var query = GetQuery(input);
                if (query == null) continue;

                lastMachine = Execute(program, query);
            }
        }

        PrologMachine Execute(Prolog.Program program, Query query)
        {
            try
            {
                var machine = PrologMachine.Create(program, query);
                machine.ExecutionComplete += CodeExecuted;
                var result = machine.RunToSuccess();
                Console.WriteLine(Enum.GetName(typeof(ExecutionResults), result));
                return machine;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, got exception: {0}", ex.Message);
                return null;
            }
        }

        void CodeExecuted(object sender, PrologQueryEventArgs e)
        {
            var machine = sender as PrologMachine;
            machine.ExecutionComplete -= CodeExecuted;

            if (e.Results == null)
            {
                Console.WriteLine("No result available");
                return;
            }

            var sb = new StringBuilder();

            string prefix = null;
            foreach (var variable in e.Results.Variables)
            {
                sb.Append(prefix); prefix = Environment.NewLine;
                sb.AppendFormat("{0} = {1}", variable.Name, variable.Text);
            }

            Console.WriteLine(sb.ToString());
        }

        Query GetQuery(string input)
        {
            var buffer = input.Trim();
            if (!buffer.StartsWith(":-"))
                buffer = ":-" + buffer;
            var codeSentences = Parser.Parse(buffer);
            if (codeSentences == null || codeSentences.Length == 0)
            {
                Console.WriteLine("Query sentences were empty");
                return null;
            }
            return new Query(codeSentences[0]);
        }

        IEnumerable<CodeSentence> GetCodeSentences(string text)
        {
            var codeSentences = Parser.Parse(text);
            if (codeSentences == null)
            {
                Console.WriteLine("Code sentences were empty");
                return null;
            }
            return codeSentences;
        }
    }
}