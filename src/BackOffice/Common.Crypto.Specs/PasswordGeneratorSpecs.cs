using Machine.Fakes;
using Machine.Specifications;

namespace Common.Crypto.Specs
{
    [Subject(typeof(PasswordGenerator))]
    public class When_creating_salt : WithSubject<PasswordGenerator>
    {
        Because of = () => { _salt = Subject.Salt; };

        It should_generate_salt = () => _salt.ShouldNotBeEmpty();
        It should_have_length_44 = () => _salt.Length.ShouldEqual(44);

        static string _salt;
    }


    [Subject(typeof(PasswordGenerator))]
    public class When_creating_two_salts : WithSubject<PasswordGenerator>
    {
        Because of = () =>
            {
                _salt1 = Subject.Salt;
                _salt2 = Subject.Salt;
            };

        It should_generate_first_salt = () => _salt1.ShouldNotBeEmpty();
        It should_generate_second_salt = () => _salt2.ShouldNotBeEmpty();
        It should_generate_different_salts = () => _salt1.ShouldNotEqual(_salt2);

        static string _salt1;
        static string _salt2;
    }

    [Subject(typeof(PasswordGenerator))]
    public class When_creating_hash : WithSubject<PasswordGenerator>
    {
        Because of = () => 
            {
               _salt = Subject.Salt;
                _hash = Subject.CreateHash(_salt, _password);
            };

        It should_generate_hash = () => _hash.ShouldNotBeEmpty();
        It should_have_length_44 = () => _hash.Length.ShouldEqual(44);
        It should_be_verifiable = () => _hash.ShouldEqual(Subject.CreateHash(_salt, _password));

        static string _hash;
        static string _password = "Hello World I am a robot display all properties all shields a re up";
        static string _salt;
    }

    [Subject(typeof(PasswordGenerator))]
    public class When_creating_two_hashes_with_same_salt : WithSubject<PasswordGenerator>
    {
        Because of = () => 
            {
               var salt = Subject.Salt;
                _hash1 = Subject.CreateHash(salt, _password1);
                _hash2 = Subject.CreateHash(salt, _password2);
            };

        It should_generate_hash1 = () => _hash1.ShouldNotBeEmpty();
        It should_generate_hash2 = () => _hash2.ShouldNotBeEmpty();
        It should_differ = () => _hash1.ShouldNotEqual(_hash2);

        static string _hash1;
        static string _hash2;
        static string _password1 = "Hello World";
        static string _password2 = "Linux Mint";
    }

    [Subject(typeof(PasswordGenerator))]
    public class When_creating_two_hashes_with_different_salts : WithSubject<PasswordGenerator>
    {
        Because of = () => 
            {
                _hash1 = Subject.CreateHash(Subject.Salt, _password1);
                _hash2 = Subject.CreateHash(Subject.Salt, _password2);
            };

        It should_generate_hash1 = () => _hash1.ShouldNotBeEmpty();
        It should_generate_hash2 = () => _hash2.ShouldNotBeEmpty();
        It should_differ = () => _hash1.ShouldNotEqual(_hash2);

        static string _hash1;
        static string _hash2;
        static string _password1 = "Hello World";
        static string _password2 = "Linux Mint";
    }

    [Subject(typeof(PasswordGenerator))]
    public class When_creating_hash_with_different_salts : WithSubject<PasswordGenerator>
    {
        Because of = () => 
            {
                _hash1 = Subject.CreateHash(Subject.Salt, _password);
                _hash2 = Subject.CreateHash(Subject.Salt, _password);
            };

        It should_generate_hash1 = () => _hash1.ShouldNotBeEmpty();
        It should_generate_hash2 = () => _hash2.ShouldNotBeEmpty();
        It should_differ = () => _hash1.ShouldNotEqual(_hash2);

        static string _hash1;
        static string _hash2;
        static string _password = "Hello World";
    }
}