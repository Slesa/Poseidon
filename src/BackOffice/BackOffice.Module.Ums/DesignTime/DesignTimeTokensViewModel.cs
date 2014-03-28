using System.Collections.Generic;
using System.Collections.ObjectModel;
using Poseidon.BackOffice.Module.Ums.Contracts;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.BackOffice.Module.Ums.DesignTime
{
    public class DesignTimeTokensViewModel : ITokensViewModel
    {
        public ObservableCollection<Token> Tokens
        {
            get
            {
                return new ObservableCollection<Token>(CreateTokens());
            }
        }

        IEnumerable<Token> CreateTokens()
        {
            yield return new Token {Data = "abcabcabcef", TokenType = new TokenType {Name = "Magnetic"}};
            yield return new Token {Data = "1234", TokenType = new TokenType {Name = "Keylock"}};
            yield return new Token {Data = "AXFD-DDD-AAEE", TokenType = new TokenType {Name = "Scanner"}};
        }
    }
}