using Application.Common;
using Application.ImportCryptos;
using Application.UserCrypto;
using Application.UserForGroups.Interfaces;
using Application.UserHandling;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EntityClass = Application.UserForGroups.UserForGroupsModel;

namespace Application.UserForGroups
{
    public class UserForGroupsAppService : GenericApplicationService<EntityClass>, IUserForGroupsAppService
    {
        public UserForGroupsAppService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserForGroupsAppService() : base(ApplicationDbContext.AppDbContext)
        { }

        public override IEnumerable<EntityClass> GetAll()
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public override EntityClass GetById(int id)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(f => f.Id == id)
                .FirstOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByUserId(int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.userHandlingModel.Id == userId)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public IEnumerable<EntityClass> GetByGroupId(int groupId)
        {
            var result = dbContext.Set<EntityClass>()
                .Include(f => f.groupModel)
                .Include(e => e.userHandlingModel)
                .Where(x => x.groupModel.Id == groupId)
                .ToList();

            if (result.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            return result;
        }

        public bool IsCreator(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Where(r => r.groupModel.Id == groupId && r.userHandlingModel.Id == userId && r.accesLevel == "creator")
                .ToList();

            if (result.Count == 0)
                return false;
            else
                return true;
        }

        public bool IsMember(int groupId, int userId)
        {
            var result = dbContext.Set<EntityClass>()
                .Where(r => r.groupModel.Id == groupId && r.userHandlingModel.Id == userId)
                .ToList();

            if (result.Count == 0)
                return false;
            else
                return true;
        }

        public List<PlayerModel> GetLeaderBordByGroupId(int groupId, UserHandlingAppService userHandlingAppService, UserCryptoAppService userCryptoAppService)
        {
            List<PlayerModel> leaderBoard = new();
            List<UserForGroupsModel> userForGroupsModels = this.GetByGroupId(groupId).ToList();

            foreach (var item in userForGroupsModels)
            {
                try
                {
                    UserHandlingModel user = userHandlingAppService.GetById(item.userHandlingModelId);
                    PlayerModel player = new PlayerModel()
                    {
                        Place = 0,
                        UserForGroupsModelId = item.Id,
                        Username = user.userName,
                        ProfilePictureUrl = user.profilePictureUrl,
                        AllMoney = item.money,
                    };

                    try
                    {
                        List<UserCryptoModel> userCryptoModels = userCryptoAppService.GetByGroupAndUserId(groupId, user.Id).ToList();
                        foreach (var crypto in userCryptoModels)
                        {
                            player.AllMoney +=  CryptoData.ChangeToDollar(CryptoData.GetByCryptoSymbol(crypto.cryptoSymbol), crypto.cryptoValue);
                        }
                        leaderBoard.Add(player);
                    }
                    catch (KeyNotFoundException)
                    {
                        leaderBoard.Add(player);
                    }

                }
                catch (KeyNotFoundException) { }
            }

            leaderBoard.Sort((e, s) => s.AllMoney.CompareTo(e.AllMoney));


            int place = 1;
            for (int i = 0; i < leaderBoard.Count-1; i++)
            {
                leaderBoard[i].Place = place;
                if (leaderBoard[i].AllMoney != leaderBoard[i + 1].AllMoney)
                {
                    place++;
                }
            }
            leaderBoard[leaderBoard.Count - 1].Place = place;

            return leaderBoard;
        }
    }
}
