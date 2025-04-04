﻿using System;
using FluentNHibernate.Mapping;
using Machine.Specifications;
using Poseidon.Domain.Common;
using Poseidon.Hibernate.Specs.Common;

namespace Poseidon.Hibernate.Specs
{
    [Subject(typeof(AnyEntity))]
    internal class When_saving_an_entity : InMemoryDatabaseSpecs<AnyEntityMap>
    {
        Establish context = () =>
            {
                using (var transaction = Session.BeginTransaction())
                {
                    var entity = new AnyEntity {Name = "Darth Vader"};
                    _index = (int) Session.Save(entity);
                    transaction.Commit();
                }
            };

        Because of = () =>
            {
                _entity = Session.Load<AnyEntity>(_index);
            };

        It should_find_entity = () => _entity.ShouldNotBeNull();
        It should_find_correct_entity = () => _entity.Name.ShouldEqual("Darth Vader");

        static AnyEntity _entity;
        static int _index;
    }



    [Subject(typeof(AnyEntity))]
    internal class When_saving_same_entity_twice : InFileDatabaseSpecs<AnyEntityMap>
    {
        Establish context = () =>
            {
                var session = CreateSession();
                using (var transaction = session.BeginTransaction())
                {
                    var entity = new AnyEntity {Name = "Darth Vader"};
                    _index = (int) session.Save(entity);
                    transaction.Commit();
                }
            };

        Because of = () =>
            {
                var session1 = CreateSession();
                var try1 = session1.Load<AnyEntity>(_index);
                try1.Name = "Luke Skywalker";

                var session2 = CreateSession();
                var try2 = session2.Load<AnyEntity>(_index);
                try2.Name = "Imperator Palpatine";


                var transaction1 = session1.BeginTransaction();
                session1.SaveOrUpdate(try1);
                transaction1.Commit();
                session1.Close();

                _error = Catch.Exception(() =>
                    {
                        var transaction2 = session2.BeginTransaction();
                        session2.SaveOrUpdate(try2);
                        transaction2.Commit();
                        session2.Close();
                    });

                var session = CreateSession();
                _name = session.Load<AnyEntity>(_index).Name;
                session.Close();
            };


        It should_take_first_save = () => _name.ShouldEqual("Luke Skywalker");
        It should_fail = () => _error.ShouldBeOfType(typeof(NHibernate.StaleObjectStateException));

        static int _index;
        static Exception _error;
        static string _name;
    }


    public class AnyEntity : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
    }

    public class AnyEntityMap : ClassMap<AnyEntity>
    {
        public AnyEntityMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");
            Map(d => d.Name).Length(40);
            Version(d => d.Version);
        }
    }
}