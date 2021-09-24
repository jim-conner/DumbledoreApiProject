using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpyDuhApiProject2.Models
{
    public class SpyDuhMember: Spy
    {
        public List<Guid> Friends { get; set; }
        public List<Guid> Enemies { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Service> Services { get; set; }
    }

    //create Class for Skill and Service 

    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SpyId { get; set; }

    }

    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid SpyId { get; set; }
    }

    public class Friend
    {
        public Guid Id { get; set; }
    }

    public class Enemy
    {
        public Guid Id { get; set; }
    }

}
