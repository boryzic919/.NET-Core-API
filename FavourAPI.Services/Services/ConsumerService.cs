using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavourAPI.Dtos;
using AutoMapper;
using FavourAPI.Data.Models;
using FavourAPI.Data;

namespace FavourAPI.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public ConsumerService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // Add for now
        public bool AddOrUpdateConsumer(string userId, ConsumerDto consumerData)
        {
            var currentUserInfo = GetConsumer(userId);

            var dbConsumer = mapper.Map<Consumer>(consumerData);
            var correctSexDb = this.dbContext.Sexes.First(s => s.Value == dbConsumer.Sex.Value);
            dbConsumer.Sex = correctSexDb;
            dbConsumer.Id = userId;

            var phoneNumberDb = this.dbContext.PhoneNumbers.FirstOrDefault(number => number.Label == consumerData.PhoneNumber);
            if (phoneNumberDb != null)
            {
                dbConsumer.PhoneNumber = phoneNumberDb;
            }

            var currentUser = this.dbContext.Users.SingleOrDefault(u => u.Id == userId);
            currentUser.PermissionMy.HasSufficientInfoConsumer = true;

            dbContext.Consumers.Add(dbConsumer);

            dbContext.SaveChanges();
            return CheckForLoginProceedPermission(dbConsumer);
        }

        public ConsumerDto GetById(string userId)
        {
            var dto = this.mapper.Map<ConsumerDto>(GetConsumer(userId));
            return dto;
        }

        private Consumer GetConsumer(string userId)
        {
            return dbContext.Consumers.SingleOrDefault(c => c.Id == userId);
        }

        public bool CheckForLoginProceedPermission(Consumer consumer)
        {
            return consumer.FirstName != null && consumer.LastName != null && consumer.PhoneNumber != null;
        }

        public void SaveJobOffer(string userId, string jobOfferId)
        {
            this.dbContext.ConsumerJobOffers.Add(new ConsumerJobOffer()
            {
                JobOfferId = jobOfferId,
                ConsumerId = userId
            });

            this.dbContext.SaveChanges();
        }

    }
}
