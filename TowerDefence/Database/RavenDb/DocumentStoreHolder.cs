﻿using System;
using Raven.Client;
using Raven.Client.Embedded;

namespace TowerDefence.Database.RavenDb
{
    public class DocumentStoreHolder {
        private static readonly Lazy<IDocumentStore> _store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => _store.Value;

        private static IDocumentStore CreateStore() {
            IDocumentStore store = new EmbeddableDocumentStore {
                DataDirectory = ""
            }.Initialize();

            return store;
        }
    }
}
