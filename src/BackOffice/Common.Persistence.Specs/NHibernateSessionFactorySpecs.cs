using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using Machine.Specifications;
using NHibernate;
using Poseidon.Common.Persistence.Contracts;
using Poseidon.Hibernate.Specs.Common;
using Rhino.Mocks;

namespace Poseidon.Common.Persistence.Specs
{
    [Subject(typeof(HibernateSessionFactory))]
    internal class When_a_nhibernate_session_created_for_the_first_time
    {
        static IPersistenceConfiguration _persistenceConfiguration;
        static IHibernatePersistenceModel _persistenceModel;
        static IHibernateInitializationAware[] _initializers;
        static HibernateSessionFactory _factory;
        static ISession _session;

        Establish context = () =>
            {
                _persistenceConfiguration = MockRepository.GenerateStub<IPersistenceConfiguration>();
                _persistenceConfiguration
                    .Stub(x => x.GetConfiguration())
                    .Return(new SqLiteInMemoryDatabaseConfiguration().GetConfiguration());

                _persistenceModel = MockRepository.GenerateStub<IHibernatePersistenceModel>();
                _persistenceModel
                    .Stub(x => x.AddMappings(null))
                    .IgnoreArguments()
                    .WhenCalled(x =>
                        {
                            var config = (MappingConfiguration) x.Arguments.First();
                            config.FluentMappings.Add<MappedClassMap>();
                        });

                _initializers = new[]
                    {
                        MockRepository.GenerateStub<IHibernateInitializationAware>(),
                        MockRepository.GenerateStub<IHibernateInitializationAware>()
                    };

                _factory = new HibernateSessionFactory(_persistenceConfiguration, _persistenceModel)
                    {
                        Initializers = _initializers
                    };
            };

        Because of = () => { _session = _factory.CreateSession(); };

        It should_retrieve_the_persistence_configuration =
            () => _persistenceConfiguration.AssertWasCalled(x => x.GetConfiguration());

        It should_add_mappings_from_the_persistence_model =
            () => _persistenceModel.AssertWasCalled(x => x.AddMappings(Arg<MappingConfiguration>.Is.NotNull), o => o.Repeat.AtLeastOnce());
        /*
        It should_invoke_the_initializers_before_initialization =
            () => _initializers.Each(x => x.AssertWasCalled(i => i.BeforeInitialization()));

        It should_invoke_the_initializers_while_configuring =
            () => _initializers.Each(x => x.AssertWasCalled(i => i.Configuring(Arg<NHibernate.Cfg.Configuration>.Is.NotNull),
                // First call: by the NHSF, second call by FNH.                                           
                                                           o => o.Repeat.Twice()));

        It should_invoke_the_initializers_with_the_actual_configuration =
            () => _initializers.Each(x => x.AssertWasCalled(i => i.Configured(Arg<NHibernate.Cfg.Configuration>.Is.NotNull)));

        It should_invoke_the_initializers_with_the_session_factory =
            () => _initializers.Each(x => x.AssertWasCalled(i => i.Initialized(Arg<NHibernate.Cfg.Configuration>.Is.NotNull,
                                                                              Arg<ISessionFactory>.Is.NotNull)));
        */
        It should_be_able_to_create_a_session =
            () => _session.ShouldNotBeNull();

        It should_create_a_session_that_flushes_on_commit =
            () => _session.FlushMode.ShouldEqual(FlushMode.Commit);
    }



    [Subject(typeof(HibernateSessionFactory))]
    internal class When_a_nhibernate_session_created
    {
        static IPersistenceConfiguration _persistenceConfiguration;
        static IHibernatePersistenceModel _persistenceModel;
        static ISession _session;
        static HibernateSessionFactory _factory;
        static IHibernateInitializationAware[] _initializers;

        Establish context = () =>
            {
                _persistenceConfiguration = MockRepository.GenerateStub<IPersistenceConfiguration>();
                _persistenceConfiguration
                    .Stub(x => x.GetConfiguration())
                    .Return(new SqLiteInMemoryDatabaseConfiguration().GetConfiguration());

                _persistenceModel = MockRepository.GenerateStub<IHibernatePersistenceModel>();
                _persistenceModel
                    .Stub(x => x.AddMappings(null))
                    .IgnoreArguments()
                    .WhenCalled(x =>
                        {
                            var config = (MappingConfiguration) x.Arguments.First();
                            config.FluentMappings.Add<MappedClassMap>();
                        });

                _initializers = new[]
                    {
                        MockRepository.GenerateStub<IHibernateInitializationAware>()
                    };

                _factory = new HibernateSessionFactory(_persistenceConfiguration, _persistenceModel)
                    {
                        Initializers = _initializers
                    };

                _factory.CreateSession();

                /*            _initializers = new[]
                                       {
                                        MockRepository.GenerateStub<IHibernateInitializationAware>()
                                       };*/
            };

        Because of = () => { _session = _factory.CreateSession(); };

        It should_be_able_to_create_a_session =
            () => _session.ShouldNotBeNull();

        It should_create_a_session_that_flushes_on_commit =
            () => _session.FlushMode.ShouldEqual(FlushMode.Commit);
        /*
        It should_not_reinitialize_the_session_factory =
            () => _initializers.Each(x => x.AssertWasNotCalled(i => i.BeforeInitialization()));*/
    }




    public class MappedClass
    {
        protected MappedClass()
        {
        }

        public virtual int Id
        {
            get;
            set;
        }
    }

    public class MappedClassMap : ClassMap<MappedClass>
    {
        public MappedClassMap()
        {
            Id(x => x.Id);
        }
    }
}