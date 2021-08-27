﻿using SpyDuhApiProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.DataAccess
{
    public class SpyDuhMembersRepository
    {
        static List<SpyDuhMember> _spyDuhMembers = new List<SpyDuhMember>
        {
            new SpyDuhMember
            {
                Alias = "Harry",
                Id = Guid.Parse("e7c4af1e-c8d4-4998-a611-0b31cc62d312"),
                AboutMe = "I'm super nosy so I became a spy.",
                Skills = new List<string> { "Stealth", "Investigation", "camouflage" },
                Services = new List<string> {"Breaking in to read people's diaries", "Infiltrating an organization"},
                Friends = new List<Guid>
                {
                    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                },
                Enemies = new List<Guid>
                {
                    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                }
            },
             new SpyDuhMember
            {
                Alias = "Larry",
                Id = Guid.Parse("11692ac4-9d81-4be5-8fd3-5154b1579a94"),
                AboutMe = "I became a spy to take down evil corporations.",
                Skills = new List<string> { "Hacking", "Investigation", "Impersonation" },
                Services = new List<string> {"Breaking in to read people's diaries", "Hacking into a corporation's sensitive data"},
                Friends = new List<Guid>
                {
                    Guid.Parse("14d2d829-a609-4fe4-82ad-5dab2444e274")
                },
                Enemies = new List<Guid>
                {
                    Guid.Parse("0a0498c4-6d99-4de8-b687-127a0b89bb2a")
                }
             }
        };

        internal void Add(SpyDuhMember spyDuhMember)
        {
            _spyDuhMembers.Add(spyDuhMember);
        }

        internal IEnumerable<SpyDuhMember> GetAll()
        {
            return _spyDuhMembers;
        }
        internal SpyDuhMember GetById(Guid spyDuhId)
        {
            return _spyDuhMembers.FirstOrDefault(spyDuhMember => spyDuhMember.Id == spyDuhId);
        }

        internal void  AddFriendToSpyDuhAccount(Guid accountId, Guid friendId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            spyDuhMember.Friends.Add(friendId);
        }
        internal void RemoveFriendFromSpyDuhAccount(Guid accountId, Guid friendId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            spyDuhMember.Friends.Remove(friendId);
        }
        internal void AddEnemyToSpyDuhAccount(Guid accountId, Guid enemyId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            spyDuhMember.Enemies.Add(enemyId);
        }
        internal void RemoveEnemyFromSpyDuhAccount(Guid accountId, Guid enemyId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            spyDuhMember.Enemies.Remove(enemyId);
        }

        internal List<Guid> ShowAccountEnemies(Guid accountId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            return spyDuhMember.Enemies;
        }

        internal List<Guid> ShowAccountFriends(Guid accountId)
        {
            var repo = new SpyDuhMembersRepository();
            var spyDuhMember = repo.GetById(accountId);
            return spyDuhMember.Friends;
        }

        internal List<string> GetMemberSkills(Guid accountId)
        {
            var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
            return singleMember.Skills;
        }

        internal List<string> GetMemberServices(Guid accountId)
        {
            var singleMember = _spyDuhMembers.FirstOrDefault(member => member.Id == accountId);
            return singleMember.Services;
        }
    }
}
