﻿using MongoDB.Driver;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Cache;
using Projeto02.Infra.Data.MongoDB.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.MongoDB.Caches
{
    public class TarefaCache : ITarefaCache
    {
        //atributo..
        private readonly MongoDbContext mongoDbContext;

        //construtor para a injeção de dependência..
        public TarefaCache(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public void Create(TarefaDTO entity)
        {
            mongoDbContext.Tarefas.InsertOne(entity);
        }

        public void Update(TarefaDTO entity)
        {
            var filter = Builders<TarefaDTO>.Filter.Eq(u => u.Id, entity.Id);
            mongoDbContext.Tarefas.ReplaceOne(filter, entity);
        }

        public void Delete(TarefaDTO entity)
        {
            var filter = Builders<TarefaDTO>.Filter.Eq(u => u.Id, entity.Id);
            mongoDbContext.Tarefas.DeleteOne(filter);
        }

        public List<TarefaDTO> GetAll()
        {
            var filter = Builders<TarefaDTO>.Filter.Where(u => true);
            return mongoDbContext.Tarefas.Find(filter).ToList();
        }

        public TarefaDTO GetById(Guid id)
        {
            var filter = Builders<TarefaDTO>.Filter.Eq(u => u.Id, id);
            return mongoDbContext.Tarefas.Find(filter).FirstOrDefault();
        }
    }
}
